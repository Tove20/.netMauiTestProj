using MauiBlazorApp1.Platforms.PartialMethods;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Syncfusion.Blazor.Navigations;

namespace MauiBlazorApp1.Pages.Lists.TwoLineLists
{
    public partial class TwoLineLists
    {
        private void GoToOneLinePage()
        {
            UriHelper.NavigateTo("/lists");
        }

        private void GoToTwoLinePage()
        {
            UriHelper.NavigateTo("/twolists");
        }

        private void GoToAudits()
        {
            UriHelper.NavigateTo("/audits");
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
        Height = dimension.Height;
        Width = dimension.Width;
        contextMenuObj.Open(Width, Height);
    }
    }
}
