using Foundation;
using Microsoft.Maui.Controls.Compatibility.Platform.iOS;
using Microsoft.Maui.Controls.PlatformConfiguration;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIKit;

namespace MauiBlazorApp1.Platforms.PartialMethods
{
    public partial class FileAccessIntegration
    {
        public string GetApplicationName()
        {
            return NSBundle.MainBundle.BundleIdentifier;
        }

        public string GetAppRootPath()
        {
            var path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            return path;
        }
        public Stream ConvertJpgToPng(Stream stream)
        {
            //Convert image stream into byte array
            byte[] image = new byte[stream.Length];
            stream.Read(image, 0, image.Length);

            //Load the image
            UIKit.UIImage images = new UIImage(Foundation.NSData.FromArray(image));

            //Save the image as png
            byte[] bytes = images.AsPNG().ToArray();

            //Store the byte array into memory stream
            Stream imgStream = new MemoryStream(bytes);

            //Return the Jpeg image as stream
            return imgStream;
        }

        public void CreateThumbnaiFromStream(Stream stream, string filepath)
        {
            var memstream = ConvertJpgToPng(stream);
            var bytes = Array.Empty<byte>();

            using (var memoryStream = new MemoryStream())
            {
                memstream.CopyTo(memoryStream);
                bytes = memoryStream.ToArray();
            }

            using (FileStream fs = new FileStream(filepath, FileMode.CreateNew, FileAccess.Write))
            {
                fs.Write(bytes, 0, (int)bytes.Length);
                fs.Close();
            }

            File.WriteAllBytesAsync(filepath, bytes);

        }
    }


}
