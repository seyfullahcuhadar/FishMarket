using System;
using System.Linq;
using System.Text;
using FishMarket.Domain.Fishes.Rules;
using FishMarket.Domain.SeedWork;

namespace FishMarket.Domain.Fishes
{
    public class Image:ValueObject
    {
        public byte[] Bytes { get;}
        public string Path { get; }
        public ImageFormat ImageFormat { get; }
        public static Image Create(byte[] imageBytes,IFishImageUtility fishImageUtility)
        {
            CheckRule(new FishImageMustBeValid(GetImageFormat(imageBytes)));
            var image = new Image(imageBytes, fishImageUtility);
            return image;
        }
        private Image(byte[] imageBytes,IFishImageUtility fishImageUtility)
        {
            this.Bytes = imageBytes;
            this.Path = fishImageUtility.CopyImageBytesToFile(imageBytes);
            this.ImageFormat = GetImageFormat(imageBytes);
        }
        private Image(){}
        private static ImageFormat GetImageFormat(byte[] Bytes)
        {
            var bmp = Encoding.ASCII.GetBytes("BM");     // BMP
            var gif = Encoding.ASCII.GetBytes("GIF");    // GIF
            var png = new byte[] { 137, 80, 78, 71 };    // PNG
            var tiff = new byte[] { 73, 73, 42 };         // TIFF
            var tiff2 = new byte[] { 77, 77, 42 };         // TIFF
            var jpeg = new byte[] { 255, 216, 255, 224 }; // jpeg
            var jpeg2 = new byte[] { 255, 216, 255, 225 }; // jpeg canon
            ImageFormat imageFormat;
            if (bmp.SequenceEqual(Bytes.Take(bmp.Length)))
                imageFormat = ImageFormat.bmp;

            else if (gif.SequenceEqual(Bytes.Take(gif.Length)))
                imageFormat = ImageFormat.gif;

            else if (png.SequenceEqual(Bytes.Take(png.Length)))
                imageFormat = ImageFormat.png;

            else if (tiff.SequenceEqual(Bytes.Take(tiff.Length)))
                imageFormat = ImageFormat.tiff;

            else if (tiff2.SequenceEqual(Bytes.Take(tiff2.Length)))
                imageFormat = ImageFormat.tiff;

            else if (jpeg.SequenceEqual(Bytes.Take(jpeg.Length)))
                imageFormat = ImageFormat.jpeg;

            else if (jpeg2.SequenceEqual(Bytes.Take(jpeg2.Length)))
                imageFormat = ImageFormat.jpeg;
            else imageFormat = ImageFormat.unknown;
            return imageFormat;
        }
    }
}

