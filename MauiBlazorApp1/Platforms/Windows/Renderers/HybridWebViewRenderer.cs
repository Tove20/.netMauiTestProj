using MauiBlazorApp1.NativeControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiBlazorApp1.Platforms.Windows.Renderers
{
    public class HybridWebViewRenderer
    {
        private HybridWebView targetWebView;


        public void InitRendering(HybridWebView webView)
        {
            targetWebView = webView;

            Microsoft.Maui.Handlers.WebViewHandler.Mapper.AppendToMapping("CustomHybridWebViewMapper",
               (handler, view) =>
               {
                   var hybridView = view as HybridWebView;
                   if (hybridView == null)
                       return;
                   if (hybridView != targetWebView)
                       return;

                   handler.PlatformView.NavigationCompleted -= Wv_NavigationCompleted;
                   handler.PlatformView.WebMessageReceived -= Sender_WebMessageReceived;
                   handler.PlatformView.NavigationCompleted += Wv_NavigationCompleted;
                   handler.PlatformView.WebMessageReceived += Sender_WebMessageReceived;

               });
        }


        private async void Wv_NavigationCompleted(Microsoft.UI.Xaml.Controls.WebView2 sender, Microsoft.Web.WebView2.Core.CoreWebView2NavigationCompletedEventArgs args)
        {
            if (args.IsSuccess)
            {
                const string scriptFunction = "function invokeCSharpAction(data){window.chrome.webview.postMessage(data);}";
                await sender.ExecuteScriptAsync(scriptFunction);
            }
        }

        private void Sender_WebMessageReceived(Microsoft.UI.Xaml.Controls.WebView2 sender, Microsoft.Web.WebView2.Core.CoreWebView2WebMessageReceivedEventArgs args)
        {
            var data = args.TryGetWebMessageAsString();
            if (string.IsNullOrEmpty(data))
                return;
            targetWebView.InvokeAction(data);
        }
    }
}
