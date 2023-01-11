using Android.Content;
using Android.Graphics;
using Java.IO;
using Microsoft.Maui.Controls.Compatibility.Platform.Android;
using Microsoft.Maui.Controls.PlatformConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using android = Android;

namespace MauiBlazorApp1.Platforms.PartialMethods
{
    public partial class FileAccessIntegration
    {
        public string GetApplicationName()
        {
            return android.App.Application.Context.ApplicationInfo.NonLocalizedLabel.ToString();

        }



        public string GetAppRootPath()
        {
            Context context = android.App.Application.Context;
            var path = context.GetExternalFilesDir(null).Path; // MyDocuments
            return path;
        }
        public Stream ConvertJpgToPng(Stream stream)
        {
            //Convert image stream into byte array
            byte[] image = new byte[stream.Length];
            stream.Read(image, 0, image.Length);

            //Load the bitmap
            Bitmap resultBitmap = BitmapFactory.DecodeByteArray(image, 0, image.Length);

            //Create memory stream
            MemoryStream outStream = new MemoryStream();
            
            Bitmap resized = Bitmap.CreateScaledBitmap(resultBitmap, (int)(resultBitmap.Width * 0.3), (int)(resultBitmap.Height * 0.3), true);
            //Save the image as png
            resized.Compress(Bitmap.CompressFormat.Jpeg, 100, outStream);

            //Return the Jpeg image as stream
            return outStream;
        }

        public void CreateThumbnaiFromStream(Stream stream, string filepath)
        {
            MemoryStream memstream = new MemoryStream();
           
            var tempstream = ConvertJpgToPng(stream);
            tempstream.Position = 0;
            tempstream.CopyToAsync(memstream);

            byte[] content = memstream.ToArray();
            using (var fileStream = new FileStream(filepath, FileMode.Create, FileAccess.Write))
            {
                fileStream.Write(content, 0, content.Length);
            }

        }
    }

}
