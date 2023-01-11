using System;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace UITest
{
    public class AppInitializer
    {
        public static IApp StartApp(Platform platform)
        {
            if (platform == Platform.Android)
            {
                return ConfigureApp.Android.InstalledApp("com.companyname.mauiblazorapp1").StartApp();
            }
            //DeviceIdentifier: We get this in xcode -> window -> Devices/Simulators: Click on Simulators, Select one, Copy Indentifier
            return ConfigureApp.iOS.InstalledApp("com.companyname.mauiblazorapp1").DeviceIdentifier("7F6E3114-8F03-439C-A462-30BF0335494A").StartApp(); //Iphone SE 3
        }
    }
}