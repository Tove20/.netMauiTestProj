using System;
using Foundation;
using MauiBlazorApp1.NativeControls;
using Microsoft.Maui.Controls.Platform;
using WebKit;

namespace MauiBlazorApp1.Platforms.MacCatalyst.Renderers
{
    public class HybridWebViewRenderer : Microsoft.Maui.Controls.Compatibility.Platform.iOS.WkWebViewRenderer, IWKScriptMessageHandler //ViewRenderer<HybridWebView, WKWebView>, IWKScriptMessageHandler
    {
        const string JavaScriptFunction = "function invokeCSharpAction(data){window.webkit.messageHandlers.invokeAction.postMessage(data);}";

        private WKUserContentController userController;
        private WKWebView refWebView;
        private HybridWebView hybridWebView;

        public HybridWebViewRenderer()
        {

            refWebView = this as WKWebView;
        }


        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);

            var userController = refWebView.Configuration.UserContentController;

            var script = new WKUserScript(new NSString(JavaScriptFunction), WKUserScriptInjectionTime.AtDocumentEnd, false);
            userController.AddUserScript(script);
            userController.AddScriptMessageHandler(this, "invokeAction");


            if (e.OldElement != null)
            {
                userController.RemoveAllUserScripts();
                userController.RemoveScriptMessageHandler("invokeAction");
                var hybridWebView = e.OldElement as HybridWebView;
                hybridWebView.Cleanup();
            }
            if (e.NewElement != null)
            {
                string url = System.IO.Path.Combine(Foundation.NSBundle.MainBundle.BundlePath, "Contents", "Resources", HybridWebView.TargetUrl);

                refWebView.LoadRequest(new NSUrlRequest(new NSUrl(url, false)));
                hybridWebView = e.NewElement as HybridWebView;
            }
        }

        //protected override void OnElementChanged(ElementChangedEventArgs<HybridWebView> e)
        //{
        //    base.OnElementChanged(e);

        //    //if (Control == null)
        //    //{
        //    //    userController = new WKUserContentController();

        //    //    var script = new WKUserScript(new NSString(JavaScriptFunction), WKUserScriptInjectionTime.AtDocumentEnd, false);
        //    //    userController.AddUserScript(script);


        //    //    userController.AddScriptMessageHandler(this, "invokeAction");

        //    //    var config = new WKWebViewConfiguration { UserContentController = userController };
        //    //    config.Preferences.SetValueForKey(NSObject.FromObject(true), new NSString("allowFileAccessFromFileURLs"));

        //    //    var webView = new WKWebView(Frame, config);

        //    //    refWebView = webView;

        //    //    SetNativeControl(webView);

        //    //    //UISwipeGestureRecognizer recognizerLeft = new UISwipeGestureRecognizer(OnSwipeDetectedLeft);
        //    //    //recognizerLeft.Direction = UISwipeGestureRecognizerDirection.Left;
        //    //    //webView.AddGestureRecognizer(recognizerLeft);

        //    //    //UISwipeGestureRecognizer recognizerRight = new UISwipeGestureRecognizer(OnSwipeDetectedRight);
        //    //    //recognizerRight.Direction = UISwipeGestureRecognizerDirection.Right;
        //    //    //webView.AddGestureRecognizer(recognizerRight);

        //    //    //webView.NavigationDelegate = new MyWKNavigationDelegate();


        //    //    //Foundation.NSNotificationCenter.DefaultCenter.AddObserver(new NSString("UIDeviceOrientationDidChangeNotification"), DeviceRotated);

        //    //}
        //    //if (e.OldElement != null)
        //    //{
        //    //    userController.RemoveAllUserScripts();
        //    //    userController.RemoveScriptMessageHandler("invokeAction");
        //    //    var hybridWebView = e.OldElement as HybridWebView;
        //    //    hybridWebView.Cleanup();
        //    //}
        //    //if (e.NewElement != null)
        //    //{
        //    //    string url = Path.Combine(NSBundle.MainBundle.BundlePath, HybridWebView.TargetUrl);
        //    //    Control.LoadRequest(new NSUrlRequest(new NSUrl(url, false)));
        //    //}


        //}



        public void DidReceiveScriptMessage(WKUserContentController userContentController, WKScriptMessage message)
        {
            string data = message.Body.ToString();
            hybridWebView?.InvokeAction(message.Body.ToString());

            //NativePages.MainPage.DoSomethingStatic(data);

        }


    }

}
