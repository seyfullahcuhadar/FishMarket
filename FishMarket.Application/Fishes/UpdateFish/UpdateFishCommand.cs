using System;
using FishMarket.Application.Configuration.Commands;

namespace FishMarket.Application.Fishes.UpdateFish
{
    public class UpdateFishCommand:ICommand
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string ImagePath { get; set; }

        public UpdateFishCommand(string id, string name, double price,string imagePath)
        {
            Id = Guid.Parse(id);
            Name = name;
            Price = price;
            ImagePath = imagePath;
        }
        public UpdateFishCommand()
        {

        }
    }
}

