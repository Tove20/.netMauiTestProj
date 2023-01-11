using Microsoft.Maui.Controls.PlatformConfiguration.AndroidSpecific;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebView = Microsoft.Maui.Controls.WebView;

namespace MauiBlazorApp1.NativeControls
{
    public class HybridWebView : WebView
    {

        //public const string TargetUrl = "oldHtml/indexBlue.htm";
        public const string TargetUrl = "wwwroot/indexHybridPage.html";

        public HybridWebView()
        {

            this.On<Microsoft.Maui.Controls.PlatformConfiguration.Android>().SetMixedContentMode(MixedContentHandling.AlwaysAllow);

            //WebViewSource src = TargetUrl;

            Uri = TargetUrl;
#if WINDOWS
            //Set source
            Source = TargetUrl;
            var objRenderer = new Platforms.Windows.Renderers.HybridWebViewRenderer();
            objRenderer.InitRendering(this);
#endif
#if MACCATALYST
        //Source = System.IO.Path.Combine(Foundation.NSBundle.MainBundle.BundlePath, "Contents", "Resources" ,TargetUrl);
#endif
#if IOS
        //Source = System.IO.Path.Combine(Foundation.NSBundle.MainBundle.BundlePath ,TargetUrl);
#endif
        }



        Action<string> action;

        public static readonly BindableProperty UriProperty = BindableProperty.Create(
            propertyName: "Uri",
            returnType: typeof(string),
            declaringType: typeof(HybridWebView),
            defaultValue: default(string));

        public string Uri
        {
            get { return (string)GetValue(UriProperty); }
            set { SetValue(UriProperty, value); }
        }

        public void RegisterAction(Action<string> callback)
        {
            action = callback;
        }

        public void Cleanup()
        {
            action = null;
        }


        public void InvokeAction(string data)
        {
            if (action == null || data == null)
            {
                return;
            }
            action.Invoke(data);
        }
    }
}
