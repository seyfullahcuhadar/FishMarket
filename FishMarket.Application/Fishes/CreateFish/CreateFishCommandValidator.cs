using System;
using FluentValidation;

namespace FishMarket.Application.Fishes.CreateFish
{
    public class CreateFishCommandValidator : AbstractValidator<CreateFishCommand>
    {
        public CreateFishCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is empty");

            RuleFor(x => x.Price).GreaterThan(0);
        }
    }
}

