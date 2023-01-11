
namespace MauiBlazorApp1.Pages.Lists.OneLineLists
{
    public partial class Lists
    {
        private bool isChecked = true;

        protected override void OnInitialized()
        {
            MainPage.hideWebBrowserFunction();
        }
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
    }
}
