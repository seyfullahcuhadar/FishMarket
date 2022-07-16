using System;
using System.IO;
using FishMarket.Domain.Fishes;

namespace FishMarket.Infrastructure.Domain.Fishes
{
    public class FishImageUtility:IFishImageUtility
    {
       public string CopyImageBytesToFile(byte[] imageBytes)
        {
            var filePath = Path.Combine(Environment.CurrentDirectory,"fishImages");


            using (var ms = new MemoryStream(imageBytes))
            {
                using (var fs = new FileStream(filePath, FileMode.Create))
                {
                    ms.WriteTo(fs);
                    return filePath;
                }
            }

        }
    }
}

