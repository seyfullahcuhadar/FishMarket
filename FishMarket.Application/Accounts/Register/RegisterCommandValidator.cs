using FishMarket.Application.Accounts.Login;
using FluentValidation;

namespace FishMarket.Application.Accounts.Register
{
    public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
    {
        public RegisterCommandValidator()
        {
            RuleFor(x => x.Username).NotEmpty().WithMessage("Please enter the username");
            RuleFor(x=>x.Password).NotEmpty().WithMessage("Please enter the password");
            RuleFor(x => x).Custom((x, context) =>
            {
                if (x.Password != x.ConfirmPassword)
                {
                    context.AddFailure(nameof(x.Password), "Passwords should match");
                }
            });


        }
    }
}

