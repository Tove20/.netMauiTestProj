using IdentityModel.Client;
using IdentityModel.OidcClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiBlazorApp1.OpenId
{
    public class OpenIdInitialization
    {
        public static OidcClient GetOidcClient()
        {
            //return new OidcClient(new()
            //{
            //    Authority = ",

            //    ClientId = "interactive.public",
            //    Scope = "openid profile api",
            //    RedirectUri = "myapp://callback",

            //    Browser = new MauiAuthenticationBrowser()
            //});


            return new OidcClient(new()
            {
                Authority = "",

                ClientId = "",
                Scope = "User.Read openid email",
                RedirectUri = "myapp://callback",

                Policy = new Policy
                {
                    Discovery = new DiscoveryPolicy
                    {
                        ValidateEndpoints = false,
                        ValidateIssuerName = false,
                        Authority = "3"
                    },
                    RequireAccessTokenHash = false//,
                                                  //RequireIdentityTokenSignature = false
                },

                Browser = new MauiAuthenticationBrowser()
            });


        }


    }
}
