using System;
using System.Threading.Tasks;
using FishMarket.Application.Configuration.Identity;
using Microsoft.AspNetCore.Identity;

namespace FishMarket.Infrastructure.Identity
{
    public class AccountManager:IAccountService
    {
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly UserManager<ApplicationUser> userManager;

        public AccountManager(SignInManager<ApplicationUser> signInManager,UserManager<ApplicationUser> userManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
        }
        public async Task<bool> LoginAsync(string username,string password,bool rememberMe)
        {
            var loginResult = await signInManager.PasswordSignInAsync(username, password, rememberMe, false);
            return loginResult.Succeeded;
        }
        public async Task RegisterAsync(string username,string password)
        {
            var applicationUser = new ApplicationUser
            {
                UserName = username,
                Email = username
            };
            var result = await userManager.CreateAsync(applicationUser, password);

        }
        public async Task ConfirmEmail(string email,string token)
        {
            var user = await userManager.FindByEmailAsync(email);
            if (user != null)
                throw  new EmailNotFoundException();

            var result = await  userManager.ConfirmEmailAsync(user, token);
            if (!result.Succeeded)
                throw new Exception("Email confirm has been failed");

        }
    }
}

