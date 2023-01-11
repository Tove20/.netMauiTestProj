using Android.Content;
using Android.Webkit;
using Java.Interop;
using Microsoft.Maui.Controls.Handlers.Compatibility;
using Microsoft.Maui.Controls.Platform;
using Microsoft.Maui.Controls.Compatibility.Platform.Android.AppCompat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebKit = Android.Webkit;
using Microsoft.Maui.Controls.Compatibility.Platform.Android;
using WebView = Android.Webkit.WebView;
using MauiBlazorApp1.NativeControls;

namespace MauiBlazorApp1.Platforms.Android.Renderers
{
    public class HybridWebViewRenderer : WebViewRenderer
    {
        const string JavaScriptFunction = "function invokeCSharpAction(data){jsBridge.invokeAction(data);}";
        Context _context;
        WebView webView;

        public HybridWebViewRenderer(Context context) : base(context)
        {
            _context = context;
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Microsoft.Maui.Controls.WebView> e)
        {
            base.OnElementChanged(e);


            if (Control == null)
            {
                webView = new WebView(_context);
                webView.Settings.JavaScriptEnabled = true;
                webView.Settings.AllowFileAccessFromFileURLs = true;
                webView.Settings.AllowUniversalAccessFromFileURLs = true;
                webView.Settings.AllowContentAccess = true;
                webView.Settings.AllowFileAccess = true;
                webView.Settings.DomStorageEnabled = true;
                webView.Settings.DatabaseEnabled = true;

                //webView.LayoutParameters = new Android.Widget.RelativeLayout.LayoutParams(LayoutParams.MatchParent, LayoutParams.MatchParent);

                //webView.SetLayerType(Android.Views.LayerType.Hardware, null);
                //webView.SetWebChromeClient(new CustomWebChromeClient());

                webView.SetWebViewClient(new JavascriptWebViewClient(string.Format("javascript: {0}", JavaScriptFunction)));
                //webView.SetWebChromeClient(new CustomWebChromeClient());

                //gestureDetector = new GestureDetector(_context, this);

                //webView.Touch += (object sender, TouchEventArgs touch) => {
                //    touch.Handled = false;
                //};
                //webView.Touch += OnTouchEvent;

                SetNativeControl(webView);
            }



            if (e.OldElement != null)
            {
                Control.RemoveJavascriptInterface("jsBridge");
                ((HybridWebView)Element).Cleanup();
            }
            if (e.NewElement != null)
            {
                Control.SetWebViewClient(new JavascriptWebViewClient($"javascript: {JavaScriptFunction}"));
                Control.AddJavascriptInterface(new JSBridge(this), "jsBridge");
                Control.LoadUrl($"file:///android_asset/{((HybridWebView)Element).Uri}");
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //((HybridWebView)Element).Cleanup();
            }
            base.Dispose(disposing);
        }


    }

    public class JSBridge : Java.Lang.Object
    {
        readonly WeakReference<HybridWebViewRenderer> hybridWebViewRenderer;

        public JSBridge(HybridWebViewRenderer hybridRenderer)
        {
            hybridWebViewRenderer = new WeakReference<HybridWebViewRenderer>(hybridRenderer);
        }

        [JavascriptInterface]
        [Export("invokeAction")]
        public void InvokeAction(string data)
        {
            HybridWebViewRenderer hybridRenderer;

            if (hybridWebViewRenderer != null && hybridWebViewRenderer.TryGetTarget(out hybridRenderer))
            {
                ((HybridWebView)hybridRenderer.Element).InvokeAction(data);
            }
        }
    }

    public class JavascriptWebViewClient : WebViewClient
    {
        string _javascript;

        public JavascriptWebViewClient(string javascript)
        {
            _javascript = javascript;
        }

        public override void OnPageFinished(WebView view, string url)
        {
            base.OnPageFinished(view, url);
            view.EvaluateJavascript(_javascript, null);
        }
    }
}
