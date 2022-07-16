using System;
using FishMarket.Application.Configuration.Commands;

namespace FishMarket.Application.Fishes.CreateFish
{
    public class CreateFishCommand:ICommand
    {
        public byte[] ImageBytes { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }

    }
}

