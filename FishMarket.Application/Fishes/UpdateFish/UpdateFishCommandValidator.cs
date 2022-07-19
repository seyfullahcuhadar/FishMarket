using System;
using FluentValidation;

namespace FishMarket.Application.Fishes.UpdateFish
{
    public class UpdateFishCommandValidator : AbstractValidator<UpdateFishCommand>
    {
        public UpdateFishCommandValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty();
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Price).NotNull().NotEmpty().GreaterThan(0);

        }
    }
}

