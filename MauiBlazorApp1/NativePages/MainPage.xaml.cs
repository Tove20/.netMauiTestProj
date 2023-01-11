using ECertMobile.NativePages;
using MauiBlazorApp1.NativeControls;

using Exception = System.Exception;

namespace MauiBlazorApp1.NativePages;

public partial class MainPage : ContentPage
{
    
    public MainPage()
	{
		InitializeComponent();
        this.BackgroundColor = new Color(0, 0, 0, 0.04f);


		btnClose.Clicked += BtnClose_Clicked;
        hwvBrowser.RegisterAction(data => DoSomething(data));
    }

    
    private async void DoSomething(string data)
    {
        HelperFunctions.DeviceDisplayInfo.LoadInfoData();
        var temp = HelperFunctions.DeviceDisplayInfo.GetDisplayInfo();
        ErrorMessagePage popup = new ErrorMessagePage(
            "Height : " + temp.ScreenHeight + "\n" +
            "Width : " + temp.ScreenWidth + "\n" +
            "Density : " + temp.ScreenDensity + "\n" +
            "Orientation : " + temp.ScreenOrientation);
        try
        {
#if ANDROID
            MainThread.BeginInvokeOnMainThread(async () =>
            {
                await App.Current.MainPage.Navigation.PushModalAsync(popup);
            });
#else
             await App.Current.MainPage.Navigation.PushModalAsync(popup);
#endif


        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
    }

    public async static void DoSomethingStatic(string data)
    {
        await  App.Current.MainPage.DisplayAlert("Alert", "Hello " + data, "OK");
    }

    private void BtnClose_Clicked(object sender, EventArgs e)
	{
        Navigation.PopModalAsync(true);
    }


      
    }
