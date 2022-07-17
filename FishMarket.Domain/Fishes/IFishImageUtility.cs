using System;
namespace FishMarket.Domain.Fishes
{
    public interface IFishImageUtility
    {
        public string CopyImageBytesToFile(byte[] imageBytes,ImageFormat imageFormat);
    }
}

