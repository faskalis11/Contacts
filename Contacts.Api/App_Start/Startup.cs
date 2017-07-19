using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.Facebook;
using Microsoft.Owin.Security.Google;
using Owin;
using System;

[assembly: OwinStartup(typeof(Contacts.Api.App_Start.Startup))]

namespace Contacts.Api.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // Enable the application to use a cookie to store information for the signed in user
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ExternalCookie,
                ExpireTimeSpan = new TimeSpan(0, 30, 0)
            });

            // Use a cookie to temporarily store information about a user logging in with a third party login provider
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            app.UseFacebookAuthentication(new FacebookAuthenticationOptions()
            {
                AppId = "326718451090396",
                AppSecret = "ccd4c4eb1a2bb944483bc88c22691bfa"
            });

            app.UseGoogleAuthentication(new GoogleOAuth2AuthenticationOptions()
            {
                ClientId = "174311077733-dvullj1eo81jm1nni3qarmd5o27egflh.apps.googleusercontent.com",
                ClientSecret = "zo5HHYvfLzKawwtGiFCD0m6i"
            });
        }
    }
}
