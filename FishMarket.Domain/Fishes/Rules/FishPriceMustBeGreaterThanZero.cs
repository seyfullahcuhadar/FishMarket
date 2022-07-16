using System;
using FishMarket.Domain.SeedWork;

namespace FishMarket.Domain.Fishes.Rules
{
    public class FishPriceMustBeGreaterThanZero:IBusinessRule
    {
        private readonly string name;
        private readonly double price;

        public FishPriceMustBeGreaterThanZero(string name,double price)
        {
            this.name = name;
            this.price = price;
        }

        public string Message => $"{name}' price must be greater than zero";

        public bool IsBroken()
        {
            return price <= 0;
        }
    }
}

