using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using MauiBlazorApp1.Platforms.PartialMethods;

namespace MauiBlazorApp1.Pages
{
    public partial class Counter
    {
        [Inject]
        public IJSRuntime JSRuntime { get; set; }
        private IJSObjectReference _jsModule;

   
        protected override async Task OnInitializedAsync()
        {
            MainPage.hideWebBrowserFunction();

            var targetUrl = "./scripts/ChangelColorScript.js";
            await JSRuntime.InvokeVoidAsync("loadJs", targetUrl);
            string content = "secondary";
            await JSRuntime.InvokeVoidAsync("changeStyle", content);
            //    //_jsModule = await JSRuntime.InvokeAsync<IJSObjectReference>("import", "./Script2Test.js");
            //    //await JSRuntime.InvokeAsync<IJSObjectReference>("import", "./Script2Test.js");

            //    await JSRuntime.InvokeVoidAsync("loadScript", "./Script2Test.js");
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            var targetUrl = "./Script2Test.js";
            await JSRuntime.InvokeVoidAsync("loadJs", targetUrl);


        }


        //public void DoGreeting()
        //{
        //    _jsModule.InvokeVoidAsync(
        //                    "Script2Test.SayHello");
        //}



        private int currentCount = 0;

        private void IncrementCount()
        {
            currentCount++;
        }


    }
}
