using Android.App;
using Android.Content;
using Android.Content.PM;
using System;
using System.Threading.Tasks;
using android = Android;

namespace MauiBlazorApp1.Platforms.Android
{

    [android.App.Activity(NoHistory = true, LaunchMode = LaunchMode.SingleTop)]
    [IntentFilter(new[] { Intent.ActionView },
    Categories = new[] { Intent.CategoryDefault, Intent.CategoryBrowsable },
    DataScheme = "myapp",
    DataHost = "callback")]

    public class WebAuthenticationCallbackActivity : WebAuthenticatorCallbackActivity
    {

    }

}
