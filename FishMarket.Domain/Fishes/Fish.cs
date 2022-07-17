using System;
using FishMarket.Domain.Fishes.Rules;
using FishMarket.Domain.SeedWork;

namespace FishMarket.Domain.Fishes
{
    public class Fish:Entity,IAggregateRoot
    {
        public string Name { get; private set; }
        public double Price { get; private set; }
        public Image Image { get; private set; }
        public string ImagePath { get; private set; }


        private Fish(string name, double price,string imagePath)
        {
            Name = name;
            Price = price;
            ImagePath = imagePath;
        }

        private Fish()
        {

        }

        public static Fish Create(string name,double price,byte[] imageBytes,IFishImageUtility fishImageUtility)
        {
            CheckRule(new FishPriceMustBeGreaterThanZero(name, price));
            var fishImage = Image.Create(imageBytes, fishImageUtility);
            var fish  = new Fish(name, price, fishImage.Path);
            return fish;
        }

        public void Update(string name, double price)
        {
            this.Name = name;
            this.Price = price;
        }
    }
}

