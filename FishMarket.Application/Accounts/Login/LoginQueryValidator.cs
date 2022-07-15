using FluentValidation;


namespace FishMarket.Application.Accounts.Login
{
    public class LoginQueryValidator : AbstractValidator<LoginQuery>
    {
        public LoginQueryValidator()
        {
            RuleFor(x => x.Username).NotEmpty().WithMessage("Username is empty");

            RuleFor(x => x.Password).NotEmpty().WithMessage("Password is empty");
        }
    }
}
