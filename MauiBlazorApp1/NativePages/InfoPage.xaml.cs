using System.Diagnostics;

namespace MauiBlazorApp1.NativePages;

public partial class InfoPage : ContentPage
{
	public InfoPage()
	{
		InitializeComponent();
	}

    private async void ShowAlert(object sender, EventArgs e)
    {
        try
        {
            bool answer = await DisplayAlert("Question?", "Would you like to play a game", "Yes", "No");
            Debug.WriteLine("Answer: " + answer);
        }
        catch (Exception)
        {

        }

    }
    private async void ShowActionSheet(object sender, EventArgs e)
    {
        try
        {
            string action = await DisplayActionSheet("ActionSheet: Send to?", "Cancel", null, "Email", "Twitter", "Facebook");
            Debug.WriteLine("Action: " + action);
        }
        catch (Exception)
        {

        }

    }
    private async void ShowPrompt(object sender, EventArgs e)
    {
        try
        {
           string result = await DisplayPromptAsync("Question 1", "What's your name?");
        }
        catch (Exception)
        {

        }

    }

}