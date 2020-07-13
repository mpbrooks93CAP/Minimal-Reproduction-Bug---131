using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OpenIdConnect;
using Okta.AspNet;
using Owin;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;

[assembly: OwinStartupAttribute(typeof(Minimal_Reproduction_Bug___131.Startup))]
namespace Minimal_Reproduction_Bug___131
{
    public partial class Startup
    {

        public void Configuration(IAppBuilder app)
        {
            ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls12;
            app.SetDefaultSignInAsAuthenticationType(CookieAuthenticationDefaults.AuthenticationType);

            app.UseCookieAuthentication(new CookieAuthenticationOptions());

            app.UseOktaMvc(new OktaMvcOptions()
            {
                OktaDomain = ConfigurationManager.AppSettings["okta:OktaDomain"],
                ClientId = ConfigurationManager.AppSettings["okta:ClientId"],
                ClientSecret = ConfigurationManager.AppSettings["okta:ClientSecret"],
                RedirectUri = ConfigurationManager.AppSettings["okta:RedirectUri"],
                PostLogoutRedirectUri = ConfigurationManager.AppSettings["okta:PostLogoutRedirectUri"],
                GetClaimsFromUserInfoEndpoint = true,
                Scope = new List<string> { "openid", "profile", "email" },
            });

        }
    }
}