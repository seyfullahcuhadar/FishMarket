using System;
using FishMarket.Application.Configuration.Identity;
using FishMarket.Infrastructure.Database;
using FishMarket.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FishMarket.Infrastructure
{
    public static class DependencyInjection
    {
        public static void AddInfrastructure(this IServiceCollection services,string connectionString)
        {
            services.AddDbContext<AppIdentityDbContext>(options => options.UseSqlServer(connectionString));
            services.AddIdentity<ApplicationUser, IdentityRole>()
                 .AddDefaultTokenProviders()
                 .AddUserManager<UserManager<ApplicationUser>>()
                 .AddSignInManager<SignInManager<ApplicationUser>>()
                 .AddEntityFrameworkStores<AppIdentityDbContext>();
            services.AddDbContext<ApplicationDbContext>(x => x.UseSqlServer(connectionString));

            services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(5);

                options.LoginPath = "/Account/Login";
                options.AccessDeniedPath = "/Identity/Account/AccessDenied";
                options.SlidingExpiration = true;
            });
            services.AddScoped<IAccountService, AccountManager>();

        }
    }
}

