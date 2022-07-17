using System;
using System.IO;
using FishMarket.Domain.Fishes;
using Microsoft.AspNetCore.Hosting;

namespace FishMarket.Infrastructure.Domain.Fishes
{
    public class FishImageUtility:IFishImageUtility
    {
        private readonly IWebHostEnvironment webHostEnvironment;

        public FishImageUtility(IWebHostEnvironment webHostEnvironment)
        {
            this.webHostEnvironment = webHostEnvironment;
        }


       public string CopyImageBytesToFile(byte[] imageBytes,ImageFormat imageFormat)
        {
            var directoryName = "fishImages";
            var guid = Guid.NewGuid().ToString();
            var uniqueImagePath = Path.Combine(directoryName, guid+ "." + imageFormat.ToString());

            var directoryPath = Path.Combine(webHostEnvironment.WebRootPath, directoryName);
            Directory.CreateDirectory(directoryPath);

            var exactImageFilePath = Path.Combine(webHostEnvironment.WebRootPath, uniqueImagePath);

            using (var ms = new MemoryStream(imageBytes))
            {
                using (var fs = new FileStream(exactImageFilePath, FileMode.Create))
                {
                    ms.WriteTo(fs);
                    return uniqueImagePath;
                }
            }

        }
    }

}

