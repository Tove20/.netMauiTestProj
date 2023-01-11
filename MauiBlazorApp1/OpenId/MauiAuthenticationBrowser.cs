using IdentityModel.Client;
using IdentityModel.OidcClient.Browser;
using System.Diagnostics;

namespace MauiBlazorApp1.OpenId
{

    public class MauiAuthenticationBrowser : IdentityModel.OidcClient.Browser.IBrowser
    {
        //public async Task<BrowserResult> InvokeAsync(BrowserOptions options, CancellationToken cancellationToken = default)
        //{
        //    try
        //    {
        //        var result = await WebAuthenticator.Default.AuthenticateAsync(
        //            new Uri(options.StartUrl),
        //            new Uri(options.EndUrl));

        //        var url = new RequestUrl("myapp://callback")
        //            .Create(new Parameters(result.Properties));

        //        return new BrowserResult
        //        {
        //            Response = url,
        //            ResultType = BrowserResultType.Success
        //        };
        //    }
        //    catch (TaskCanceledException)
        //    {
        //        return new BrowserResult
        //        {
        //            ResultType = BrowserResultType.UserCancel
        //        };
        //    }
        //}


        public async Task<BrowserResult> InvokeAsync(BrowserOptions options, CancellationToken cancellationToken = default)
        {

#if WINDOWS
        try
        {
    Microsoft.Maui.Authentication.WebAuthenticatorResult authResult =
                await MauiBlazorApp1.Platforms.Windows.WinUIExOpenId.WebAuthenticator.AuthenticateAsync(new Uri(options.StartUrl), new Uri("myapp://callback")); // Add your callback URL 

            var authorizeResponse = ToRawIdentityUrl(options.EndUrl, authResult);

            return new BrowserResult
            {
                Response = authorizeResponse
            };
        }
        catch (TaskCanceledException ex)
        {
            Debug.WriteLine(ex);
            return new BrowserResult
            {
                ResultType = BrowserResultType.UserCancel
            };
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            return new BrowserResult()
            {
                ResultType = BrowserResultType.UnknownError,
                Error = ex.ToString()
            };
        }
#else
            try
            {
                var result = await WebAuthenticator.Default.AuthenticateAsync(
                    new Uri(options.StartUrl),
                    new Uri(options.EndUrl));

                var url = new RequestUrl("myapp://callback")
                    .Create(new Parameters(result.Properties));

                return new BrowserResult
                {
                    Response = url,
                    ResultType = BrowserResultType.Success
                };
            }
            catch (TaskCanceledException)
            {
                return new BrowserResult
                {
                    ResultType = BrowserResultType.UserCancel
                };
            }

#endif



        }

        public string ToRawIdentityUrl(string redirectUrl, WebAuthenticatorResult result)
        {
            try
            {
                IEnumerable<string> parameters = result.Properties.Select(pair => $"{pair.Key}={pair.Value}");
                var modifiedParameters = parameters.ToList();

                var stateParameter = modifiedParameters
                    .FirstOrDefault(p => p.StartsWith("state", StringComparison.OrdinalIgnoreCase));

                if (!string.IsNullOrWhiteSpace(stateParameter))
                {
                    // Remove the state key added by WebAuthenticator that includes appInstanceId
                    modifiedParameters = modifiedParameters.Where(p => !p.StartsWith("state", StringComparison.OrdinalIgnoreCase)).ToList();

                    stateParameter = System.Web.HttpUtility.UrlDecode(stateParameter).Split('&').Last();
                    modifiedParameters.Add(stateParameter);
                }
                var values = string.Join("&", modifiedParameters);
                return $"{redirectUrl}#{values}";
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                throw;
            }
        }
    }


}
