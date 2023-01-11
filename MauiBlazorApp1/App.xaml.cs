namespace MauiBlazorApp1;

public partial class App : Application
{
	public App()
	{
        try
        {
            InitializeComponent();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message); // Optional: A breakpoint in here
        }
        var page = new MainPage();
        MainPage = new NavigationPage(page);
        NavigationPage.SetHasNavigationBar(page, false);

        //MainPage = new MainPage();
	}


    public static Microsoft.Maui.Controls.Page GetCurrentPage()
    {
        Microsoft.Maui.Controls.Page ret = null;
        if (Application.Current.MainPage.Navigation.NavigationStack != null)
            ret = Application.Current.MainPage.Navigation.NavigationStack.LastOrDefault();

        if (ret == null)
            ret = Application.Current.MainPage;

        return ret;
    }
}
