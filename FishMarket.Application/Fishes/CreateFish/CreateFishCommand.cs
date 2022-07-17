using FishMarket.Application.Configuration.Commands;
using Microsoft.AspNetCore.Http;

namespace FishMarket.Application.Fishes.CreateFish
{
    public class CreateFishCommand:ICommand
    {
        public byte[] ImageBytes { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public IFormFile ImageFormFile { get; set; }

    }
}

