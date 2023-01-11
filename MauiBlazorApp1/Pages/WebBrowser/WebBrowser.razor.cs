using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MauiBlazorApp1.Platforms.PartialMethods;

namespace MauiBlazorApp1.Pages.WebBrowser
{
    public partial class WebBrowser
    {
        protected override void OnInitialized()
        {
            MainPage.showWebBrowserFunction();
        }
    }
}
