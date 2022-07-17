using System;
using FishMarket.Application.Configuration.Commands;

namespace FishMarket.Application.Fishes.UpdateFish
{
    public class UpdateFishCommand:ICommand
    {
        public Guid Id { get; }
        public string Name { get; }
        public double Price { get; }

        public UpdateFishCommand(string id, string name, double price)
        {
            Id = Guid.Parse(id);
            Name = name;
            Price = price;
        }
    }
}

