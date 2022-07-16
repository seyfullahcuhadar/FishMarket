using System;
using FishMarket.Domain.SeedWork;

namespace FishMarket.Domain.Fishes.Rules
{
    public class FishImageMustBeValid:IBusinessRule
    {
        private readonly ImageFormat imageFormat;

        public FishImageMustBeValid(ImageFormat imageFormat)
        {
            this.imageFormat = imageFormat;
        }

        public string Message => "Image must be valid";

        public bool IsBroken()
        {
         return imageFormat == ImageFormat.unknown;
        }
    }
}

