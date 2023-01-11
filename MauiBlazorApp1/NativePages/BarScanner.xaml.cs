
using System;
using System.Linq;
//using Microsoft.Maui.ApplicationModel;
//using Microsoft.Maui.Controls;
//using ZXing.Net.Maui;
//using ZXing;

//https://github.com/Redth/BigIslandBarcoding
namespace MauiBlazorApp1.NativePages
{
    public partial class BarScanner : ContentPage
    {
        public BarScanner()
        {
            InitializeComponent();

            //            barcodeView.Options = new BarcodeReaderOptions
            //            {
            //                Formats = BarcodeFormats.All,
            //                AutoRotate = true,
            //                Multiple = true
            //            };
            //        }

            //        protected void BarcodesDetected(object sender, BarcodeDetectionEventArgs e)
            //        {
            //            foreach (var barcode in e.Results)
            //                Console.WriteLine($"Barcodes: {barcode.Format} -> {barcode.Value}");

            //            MainThread.InvokeOnMainThreadAsync(() =>
            //            {
            //                var r = e.Results.First();

            //                barcodeGenerator.Value = r.Value;
            //                barcodeGenerator.Format = r.Format;
            //            });
            //        }

            //        //void SwitchCameraButton_Clicked(object sender, EventArgs e)
            //        //{
            //        //    barcodeView.CameraLocation = barcodeView.CameraLocation == CameraLocation.Rear ? CameraLocation.Front : CameraLocation.Rear;
            //        //}

            //        //void TorchButton_Clicked(object sender, EventArgs e)
            //        //{
            //        //    barcodeView.IsTorchOn = !barcodeView.IsTorchOn;
            //        //}
        }
    }
}
//private async void BtnScan_Clicked(object sender, EventArgs e)
//{

//        //#if __ANDROID__
//        //// Initialize the scanner first so it can track the current context
//        //MobileBarcodeScanner.Initialize(Application);
//        //#endif

//        var scanner = new ZXing.Mobile.MobileBarcodeScanner();

//        var result = await scanner.Scan();

//        if (result != null)
//            Console.WriteLine("Scanned Barcode: " + result.Text);

//}