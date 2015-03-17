using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using EPA.CUSTOM.Providers;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using Microsoft.Owin.Security.Google;
using Microsoft.Owin.Security.Facebook;
using Microsoft.AspNet.Identity;

[assembly: OwinStartup(typeof(EPA.CUSTOM.Startup))]

namespace EPA.CUSTOM
{
    public class Startup
    {
        public static OAuthBearerAuthenticationOptions OAuthBearerOptions { get; private set; }
        public static GoogleOAuth2AuthenticationOptions googleAuthOptions { get; private set; }
        public static FacebookAuthenticationOptions facebookAuthOptions { get; private set; }

        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();

            ConfigureOAuth(app);

            WebApiConfig.Register(config);
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            app.UseWebApi(config);
        }

        public void ConfigureOAuth(IAppBuilder app)
        {
            //use a cookie to temporarily store information about a user logging in with a third party login provider
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);
            OAuthBearerOptions = new OAuthBearerAuthenticationOptions();

            OAuthAuthorizationServerOptions OAuthServerOptions = new OAuthAuthorizationServerOptions()
            {

                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(30),
                Provider = new SimpleAuthorizationServerProvider()
            };

            // Token Generation
            app.UseOAuthAuthorizationServer(OAuthServerOptions);
            app.UseOAuthBearerAuthentication(OAuthBearerOptions);

            //Configure Google External Login
            googleAuthOptions = new GoogleOAuth2AuthenticationOptions()
            {
                ClientId = "745272813411-p6jgjjp7ci349gopfdbmsd35fna5u4ib.apps.googleusercontent.com",
                ClientSecret = "jGAyHZgdJG3Xqr3NYlybHvvh",
                Provider = new GoogleOAuth2AuthenticationProvider()
            };
            app.UseGoogleAuthentication(googleAuthOptions);

            /*app.UseGoogleAuthentication(new GoogleOAuth2AuthenticationOptions
           {
               ClientId = "745272813411-p6jgjjp7ci349gopfdbmsd35fna5u4ib.apps.googleusercontent.com",
               ClientSecret = "jGAyHZgdJG3Xqr3NYlybHvvh"
           });
            

            

            app.UseGoogleAuthentication(new GoogleOAuth2AuthenticationOptions()
            {
                ClientId = "745272813411-p6jgjjp7ci349gopfdbmsd35fna5u4ib.apps.googleusercontent.com",
                ClientSecret = "jGAyHZgdJG3Xqr3NYlybHvvh"
            });*/

            //app.UseGoogleAuthentication("745272813411-p6jgjjp7ci349gopfdbmsd35fna5u4ib.apps.googleusercontent.com", "jGAyHZgdJG3Xqr3NYlybHvvh");

            //app.UseGoogleAuthentication(clientId: "745272813411-p6jgjjp7ci349gopfdbmsd35fna5u4ib.apps.googleusercontent.com", clientSecret: "jGAyHZgdJG3Xqr3NYlybHvvh");

            //Configure Facebook External Login
            facebookAuthOptions = new FacebookAuthenticationOptions()
            {
                AppId = "1635342510027465",
                AppSecret = "13f5accefbf6935219ce939c742d7a73",
                Provider = new FacebookAuthProvider()
            };
            app.UseFacebookAuthentication(facebookAuthOptions);

        }
    }
}
