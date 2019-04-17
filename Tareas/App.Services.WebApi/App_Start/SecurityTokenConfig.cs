using App.Domain.Services.Interfaces;
using HealthCare.WebServices.Rest.Security;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace App.Services.WebApi.App_Start
{
    public class SecurityTokenConfig
    {
        public static void Configure(IAppBuilder app, 
                HttpConfiguration config)
        {
            ISeguridadService seguridadService =
                (ISeguridadService)config.DependencyResolver.GetService(typeof(ISeguridadService));

            var oAuthOptions = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new Microsoft.Owin.PathString("/login"),
                AccessTokenExpireTimeSpan = TimeSpan.FromSeconds(40),
                Provider = new SecurityProvider(seguridadService)
            };

            app.UseOAuthAuthorizationServer(oAuthOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

        }


    }
}