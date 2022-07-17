using System;
using FluentValidation;

namespace FishMarket.Application.Fishes.CreateFish
{
    public class CreateFishCommandValidator : AbstractValidator<CreateFishCommand>
    {
        public CreateFishCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty();

            RuleFor(x => x.Price).NotEmpty().GreaterThan(0);
            RuleFor(x => x.ImageFormFile).NotNull();
            RuleFor(x => x.ImageFormFile).Must(x => x.Length< 528385 * 10).WithMessage("Image size must be lower than 5MB").When(x=>x.ImageFormFile is not null);

        }
    }
}

