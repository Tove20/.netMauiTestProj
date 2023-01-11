using Microsoft.Maui.Controls.Compatibility.Platform.UWP;
using Microsoft.Maui.Controls.PlatformConfiguration;
using Microsoft.UI.Xaml.Media.Imaging;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.Graphics.Imaging;
using Windows.Storage;
using Windows.Storage.Streams;

namespace MauiBlazorApp1.Platforms.PartialMethods
{
    public partial class FileAccessIntegration
    {
        public string GetApplicationName()
        {
            return Package.Current.DisplayName;
        }


        public string GetAppRootPath()
        {
            //UWP: No right for System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments)
            return ApplicationData.Current.LocalFolder.Path;
        }
        public async Task<Stream> ConvertJpgToPng(Stream s)
        {
            byte[] resultArray = null;

            //Convert stream into byte array
            byte[] image = new byte[s.Length];
            s.Read(image, 0, image.Length);

            //Create An Instance of WriteableBitmap object  
            WriteableBitmap resultBitmap = new WriteableBitmap(1, 1);

            using (IRandomAccessStream ms = new InMemoryRandomAccessStream())
            {
                await ms.WriteAsync(image.AsBuffer());
                ms.Seek(0);

                //Set the source for WriteableBitmap  
                resultBitmap.SetSource(ms);
            }

            //Get the image data
            using (IRandomAccessStream ms = new InMemoryRandomAccessStream())
            {
                try
                {
                    byte[] bytes;

                    // Open a stream to copy the image contents to the WriteableBitmap's pixel buffer
                    using (Stream stream = resultBitmap.PixelBuffer.AsStream())
                    {
                        bytes = new byte[(uint)stream.Length];
                        await stream.ReadAsync(bytes, 0, bytes.Length);
                    }

                    // Create an encoder with the Jpeg format
                    BitmapEncoder encoder = await BitmapEncoder.CreateAsync(BitmapEncoder.PngEncoderId, ms);

                    // WriteableBitmap uses BGRA format 
                    encoder.SetPixelData(BitmapPixelFormat.Bgra8, BitmapAlphaMode.Ignore, (uint)resultBitmap.PixelWidth, (uint)resultBitmap.PixelHeight, 96, 96, bytes);

                    //resize image
                    encoder.BitmapTransform.InterpolationMode = BitmapInterpolationMode.Linear;
                    encoder.BitmapTransform.ScaledWidth = (uint)(resultBitmap.PixelWidth * 0.3);
                    encoder.BitmapTransform.ScaledHeight = (uint)(resultBitmap.PixelHeight * 0.3);

                    //Terminate the encoder bytes
                    await encoder.FlushAsync();

                    resultArray = new byte[ms.AsStream().Length];
                    await ms.AsStream().ReadAsync(resultArray, 0, resultArray.Length);
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine(e.Message);
                }
            }

            //Store the image into memory stream
            Stream imgStream = new MemoryStream(resultArray);

            //Return the Jpeg image as stream
            return imgStream;
        }

        public async void CreateThumbnaiFromStream(Stream stream, string filepath)
        {
          
            var memstream = await ConvertJpgToPng(stream);
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

            await File.WriteAllBytesAsync(filepath, bytes);

        }
    }
}
