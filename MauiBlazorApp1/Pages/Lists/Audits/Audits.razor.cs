namespace MauiBlazorApp1.Pages.Lists.Audits
{
    public partial class Audits
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
    }
}
