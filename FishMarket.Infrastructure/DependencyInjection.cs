using System;
using System.Threading.Tasks;
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
            AddIdentitySettings(services, connectionString);
            AddEmailSettings(services, configuration);
            AddDomainSettings(services, connectionString);

            
        }
     
        public static async Task ApplyMigrationsAsync(this IServiceProvider services)
        {
            await using var identityScope = services.CreateAsyncScope();
            using var appIdentityDb = identityScope.ServiceProvider.GetService<AppIdentityDbContext>();
            await appIdentityDb.Database.MigrateAsync();

            await using var scope = services.CreateAsyncScope();
            using var appdb = scope.ServiceProvider.GetService<ApplicationDbContext>();
            await appdb.Database.MigrateAsync();
        }

        private static void AddIdentitySettings(IServiceCollection services, string connectionString)
        {
            services.AddDbContext<AppIdentityDbContext>(options => options.UseSqlServer(connectionString));
            services.AddIdentity<ApplicationUser, IdentityRole>()
                 .AddDefaultTokenProviders()
                 .AddUserManager<UserManager<ApplicationUser>>()
                 .AddSignInManager<SignInManager<ApplicationUser>>()
                 .AddEntityFrameworkStores<AppIdentityDbContext>();

            services.AddScoped<IAccountService, AccountManager>();

            services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(5);

                options.LoginPath = "/Account/Login";
                options.AccessDeniedPath = "/Identity/Account/AccessDenied";
                options.SlidingExpiration = true;
            });

        }
        private static void AddEmailSettings(IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<EmailSettings>(configuration.GetSection("SMTP"));
            services.AddSingleton<IEmailSender, EmailSender>();
        }

        private static void AddDomainSettings(IServiceCollection services, string connectionString)
        {
            services.AddDbContext<ApplicationDbContext>(x => x.UseSqlServer(connectionString));
            services.AddScoped<IFishImageUtility, FishImageUtility>();
            services.AddScoped<IFishRepository, FishRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

        }
    }
}

