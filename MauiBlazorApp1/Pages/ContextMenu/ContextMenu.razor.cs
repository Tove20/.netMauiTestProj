using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Syncfusion.Blazor.Navigations;
using Syncfusion.Blazor.Buttons;
using MauiBlazorApp1.Platforms.PartialMethods;

namespace MauiBlazorApp1.Pages.ContextMenu
{
    public partial class ContextMenu
    {
        protected override void OnInitialized()
        {
            MainPage.hideWebBrowserFunction();
        }

        public int Height { get; set; }
        public int Width { get; set; }
        [Inject]
        public IJSRuntime JSRuntime { get; set; }

        public class WindowDimension
        {
            public int Width { get; set; }
            public int Height { get; set; }
        }

        SfContextMenu<Syncfusion.Blazor.Navigations.MenuItem> contextMenuObj;
        private async void OpenContextMenu(MouseEventArgs e)
        {
            var dimension = await JSRuntime.InvokeAsync<WindowDimension>("getWindowDimensions");
            Height = (int)(dimension.Height - 394);

            Width = (int)(dimension.Width * 0.5 - 320);
            if (Width < 0)
            {
                Width = 0;
            }
            contextMenuObj.Open(Width, Height);
            var targetUrl = "./scripts/BottomSheetScript.js";
            await JSRuntime.InvokeVoidAsync("loadJs", targetUrl);
            await JSRuntime.InvokeVoidAsync("addTitle");
        }

    }
}
