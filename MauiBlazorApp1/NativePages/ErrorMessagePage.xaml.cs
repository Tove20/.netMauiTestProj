using MauiBlazorApp1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ECertMobile.NativePages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ErrorMessagePage : ContentPage
    {
        public ErrorMessagePage(string error)
        {
            
            this.BackgroundColor = new Color(0, 0, 0, 0.4f);
            InitializeComponent();
            lblMessage.Text = error;
            btnCancel.Clicked += BtnCancel_Clicked;

        }

       
        private async void BtnCancel_Clicked(object sender, EventArgs e)
        {
            try
            {
                await App.Current.MainPage.Navigation.PopModalAsync(true);
            }
            catch (Exception ex)
            { 
                Console.WriteLine(ex.Message); // Optional: A breakpoint in here
            }

        }
        
    }
}