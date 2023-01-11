using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiBlazorApp1.HelperFunctions
{
    internal class DeviceDisplayInfo
    {
        private static int ScreenHeight;
        private static int ScreenWidth;
        private static double ScreenDensity;
        private static DisplayOrientation ScreenOrientation;

        public struct DisplayInfoData
        {
            public int ScreenHeight { get; set; }
            public int ScreenWidth { get; set; }
            public double ScreenDensity { get; set; }
            public DisplayOrientation ScreenOrientation { get; set; }
        }

        public static DisplayInfoData GetDisplayInfo()
        {
            if ((DeviceInfo.Current.Platform == DevicePlatform.iOS ||
                DeviceInfo.Current.Platform == DevicePlatform.MacCatalyst) &&
                MainThread.IsMainThread) //Must be the main thread for UWP and Android - otherwise reloading would not be possible now
                LoadInfoData();
            return new DisplayInfoData
            {
                ScreenHeight = ScreenHeight,
                ScreenWidth = ScreenWidth,
                ScreenDensity = ScreenDensity,
                ScreenOrientation = ScreenOrientation
            };
        }

        public static void LoadInfoData()
        {
            if (DeviceInfo.Current.Platform == DevicePlatform.iOS ||
                DeviceInfo.Current.Platform == DevicePlatform.MacCatalyst ||
                !MainThread.IsMainThread)
            {
                //iOS: Must be done in main thread
                //https://docs.microsoft.com/en-us/xamarin/essentials/device-display?context=xamarin%2Fandroid&tabs=android
                MainThread.BeginInvokeOnMainThread(SetData);
            }
            else
                SetData();
        }

        private static void SetData()
        {
            var mainDisplay = DeviceDisplay.MainDisplayInfo;
            var width = mainDisplay.Width;
            var height = mainDisplay.Height;
            var density = mainDisplay.Density;


            if (width > height) //Height is always the smaller side
            {
                ScreenWidth = Convert.ToInt32(width);
                ScreenHeight = Convert.ToInt32(height);
            }
            else
            {
                ScreenHeight = Convert.ToInt32(width);
                ScreenWidth = Convert.ToInt32(height);
            }


            ScreenDensity = density;
            ScreenOrientation = mainDisplay.Orientation;
        }
    }
}
