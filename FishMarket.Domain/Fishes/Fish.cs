using FishMarket.Domain.Fishes.Rules;
using FishMarket.Domain.SeedWork;

namespace FishMarket.Domain.Fishes
{
    public class Fish:Entity,IAggregateRoot
    {
        public string Name { get;}
        public double Price { get;}
        public Image Image { get; }
        public string ImagePath { get; set; }


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
    }
}

