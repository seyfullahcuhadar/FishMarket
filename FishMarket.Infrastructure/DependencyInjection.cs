using System;
using FishMarket.Application.Configuration.Identity;
using FishMarket.Application.Emails;
using FishMarket.Domain.Fishes;
using FishMarket.Domain.SeedWork;
using FishMarket.Infrastructure.Database;
using FishMarket.Infrastructure.Domain;
using FishMarket.Infrastructure.Domain.Fishes;
using FishMarket.Infrastructure.Emails;
using FishMarket.Infrastructure.Identity;
using Mailjet.Client;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FishMarket.Infrastructure
{
    public static class DependencyInjection
    {
        public static void AddInfrastructure(this IServiceCollection services,string connectionString,IConfiguration configuration)
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

            services.AddHttpClient<IMailjetClient, MailjetClient>(client =>
            {
                //set BaseAddress, MediaType, UserAgent
                client.SetDefaultSettings();

                client.UseBearerAuthentication("access_token");
                //or
                client.UseBasicAuthentication("apiKey", "apiSecret");
            });


            services.Configure<EmailSettings>(configuration.GetSection("SMTP"));
            services.AddSingleton<IEmailSender, EmailSender>();
            services.AddScoped<IFishImageUtility, FishImageUtility>();
            services.AddScoped<IFishRepository, FishRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}

