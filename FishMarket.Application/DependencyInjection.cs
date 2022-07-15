using System.Reflection;
using FishMarket.Application.Accounts.Register;
using FishMarket.Application.Configuration.Validation;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace FishMarket.Application
{
    public static class DependencyInjection
    {
        public static void AddApplication(this IServiceCollection services)
        {
            //services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddFluentValidation(x =>
            {
                x.DisableDataAnnotationsValidation = true;
                x.ImplicitlyValidateChildProperties = true;
                x.RegisterValidatorsFromAssemblyContaining<RegisterCommandValidator>();
            });
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));

        }
    }
}

