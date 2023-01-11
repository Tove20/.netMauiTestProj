//using Microsoft.AspNetCore.Components;
//using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiBlazorApp1.Pages
{
    public partial class Index
    {
        //[Inject]
        //public IJSRuntime JSRuntime { get; set; }
        ////Functions of the Top-Bar
        //protected override async Task OnInitializedAsync()
        //{
        //    var targetUrl = "./Script1.js";
        //    await JSRuntime.InvokeVoidAsync("loadJs", targetUrl);
        //}

        //private async void Toggle()
        //{
        //    await JSRuntime.InvokeVoidAsync("openMainSidebar");
        //}
        //private async void Close()
        //{
        //    await JSRuntime.InvokeVoidAsync("closeMainSidebar");
        //}


        private void ShowOrHideOldWeb()
        {
            var page = App.GetCurrentPage();
            var mainPage = page as MainPage;
            if (mainPage == null)
                return;
            mainPage.ShowOrHideOldWebBrowser();
        }


        private async void OpenOldEcertWebView()
        {
            var page = App.GetCurrentPage();
            var objPage = new NativePages.MainPage();
            try
            {
                await page.Navigation.PushModalAsync(objPage, true);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Fail(ex.Message);
            }
        }


        private async void OpenModalDialog()
        {
            var page = App.GetCurrentPage();
            var objPage = new NativePages.QrCodeReader();
            try
            {
                await page.Navigation.PushModalAsync(objPage);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Fail(ex.Message);
            }
        }

        private async void ShowInfoPage()
        {

            var page = App.GetCurrentPage();

            var objPage = new NativePages.InfoPage();
            try
            {

                await page.Navigation.PushAsync(objPage);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Fail(ex.Message);
            }


        }

        private async void ShowSwipePage()
        {

            var page = App.GetCurrentPage();

            var objPage = new NativePages.SwipePages.SwipePage();
            try
            {

                await page.Navigation.PushAsync(objPage);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Fail(ex.Message);
            }


        }
        private async void ShowOpenIdPage()
        {
            var page = App.GetCurrentPage();

            var objPage = new NativePages.OpenIdSample();
            try
            {

                await page.Navigation.PushAsync(objPage);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Fail(ex.Message);
            }
        }

            

    }
}
