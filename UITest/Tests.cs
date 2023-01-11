using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace UITest
{
    [TestFixture(Platform.Android)]
    [TestFixture(Platform.iOS)]
    public class Tests
    {
        IApp app;
        Platform platform;

        public Tests(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
        }

        //[Test]
        //public void WelcomeTextIsDisplayed()
        //{
        //    AppResult[] results = app.WaitForElement(c => c.Marked("Welcome to Xamarin.Forms!"));
        //    app.Screenshot("Welcome screen.");

        //    Assert.IsTrue(results.Any());
        //}

        [Test]
        public void TapNavButton()
        {
            app.Tap(c => c.WebView().Css("#app > div > div > div.top-row.ps-3.navbar.navbar-dark > div > button > span"));
          //  app.Tap(c => c.AppleWkWebwievClass.Css("#app > div > div > div.top-row.ps-3.navbar.navbar-dark > div > button > span"));
        }
    }
}
