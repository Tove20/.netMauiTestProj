
using Microsoft.Maui.Layouts;


namespace MauiBlazorApp1;

public partial class MainPage : ContentPage
{

    public static bool sidemenu = false;
    public static MainPage mainpage ;
    public static void callefunction()
    {
        mainpage.ResizeOldWebView();
    }

    public static void showWebBrowserFunction()
    {
        mainpage.ShowOldWebBrowser();
    }
    public void ShowOldWebBrowser()
    {
        wbvOldBrowser.IsVisible = true;
    }

    public static void hideWebBrowserFunction()
    {
        mainpage.hideOldWebBrowser();
    }
    public void hideOldWebBrowser()
    {
        wbvOldBrowser.IsVisible = false;
    }

    public MainPage()
	{
        mainpage = this;
		InitializeComponent();


#if MACCATALYST
        var source = System.IO.Path.Combine(Foundation.NSBundle.MainBundle.BundlePath, "Contents", "Resources" , "Raw/indexOldMain.html");
        wbvOldBrowser.Source = source;
       
#elif IOS
        var source = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "Raw/indexOldMain.html");
        wbvOldBrowser.Source = source;
#else
        wbvOldBrowser.Source = "Raw/indexOldMain.html";
#endif



        sidemenu = false;
		this.SizeChanged += MainPage_SizeChanged;
	}


	public void ShowOrHideOldWebBrowser()
	{
        wbvOldBrowser.IsVisible = !wbvOldBrowser.IsVisible;
    }
    public void ResizeOldWebView()
    {
        var width = this.Width;
        if (sidemenu)
        {
            width = width - 290;
        }
        else
        {
            width = width - 50;
        }

        var height = this.Height - 112;

        AbsoluteLayout.SetLayoutBounds(wbvOldBrowser, new Rect(1, 0.5, width, height));
        AbsoluteLayout.SetLayoutFlags(wbvOldBrowser, AbsoluteLayoutFlags.PositionProportional);
    }

    private void MainPage_SizeChanged(object sender, EventArgs e)
	{
        ResizeOldWebView();
        //Size + Layout bounds

    }
}
