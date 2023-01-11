namespace MauiBlazorApp1.NativePages;

public partial class ImagePage : ContentPage
{
    string imagePathfinal;
    public ImagePage(string imagePath)
    {
        InitializeComponent();
        imagePathfinal = imagePath;
        fileImage.Source = imagePathfinal;
    }
    private async void OnCounterClicked(object sender, EventArgs e)
    {
        try
        {
            await App.Current.MainPage.Navigation.PopModalAsync(true);
        }
        catch (Exception)
        {

        }

    }

}

