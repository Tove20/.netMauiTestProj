namespace MauiBlazorApp1.NativePages.SwipePages;

public partial class SwipePage : ContentPage
{
	public SwipePage()
	{
		InitializeComponent();
	}

    async void OnSwiped(object sender, SwipedEventArgs e)
    {
        var page = App.GetCurrentPage();
        switch (e.Direction)
        {
            case SwipeDirection.Left:
                lbl1.Text = "swipe left";

                var objPage = new SwipePage3();
                try
                {

                    await page.Navigation.PushAsync(objPage);
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.Fail(ex.Message);
                }
                break;
            case SwipeDirection.Right:
                lbl1.Text = "swipe right";


                var objPage2 = new SwipePage2();
                try
                {

                    await page.Navigation.PushAsync(objPage2);
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.Fail(ex.Message);
                }
                break;
        }
    }
}