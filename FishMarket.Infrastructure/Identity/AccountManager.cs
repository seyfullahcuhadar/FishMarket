using System;
using System.Threading.Tasks;
using FishMarket.Application.Configuration.Identity;
using Microsoft.AspNetCore.Identity;

namespace FishMarket.Infrastructure.Identity
{
    public class AccountManager : IAccountService
    {
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly UserManager<ApplicationUser> userManager;

        public AccountManager(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
        }
        public async Task<bool> LoginAsync(string username, string password, bool rememberMe)
        {
            var loginResult = await signInManager.PasswordSignInAsync(username, password, rememberMe, false);
            return loginResult.Succeeded;
        }
        public async Task<RegisterResult> RegisterAsync(string username, string password)
        {
            var applicationUser = new ApplicationUser
            {
                UserName = username,
                Email = username
            };
            var result = await userManager.CreateAsync(applicationUser, password);
            if (!result.Succeeded)
                throw new UserRegistrationFailedException(result);
            var newUser = await userManager.FindByNameAsync(username);
            var token = await userManager.GenerateEmailConfirmationTokenAsync(newUser);

            return new RegisterResult { ConfirmationToken = token, IsSucceed = result.Succeeded };
        }
        public async Task ConfirmEmailAsync(string email, string token)
        {
            var user = await userManager.FindByEmailAsync(email);
            if (user == null)
                throw new EmailNotFoundException(email);
            var tokenFixed = token.Replace(" ", "+");
            var result = await userManager.ConfirmEmailAsync(user, tokenFixed);
            if (!result.Succeeded)
                throw new EmailConfirmFailedException($"{email} confirm has been failed");

        }

        public async Task LogoutAsync()
        {
            await signInManager.SignOutAsync();
        }
    }
}

