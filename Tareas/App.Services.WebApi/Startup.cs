using System;
using System.Threading.Tasks;
using System.Web.Http;
using App.Services.WebApi.App_Start;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(App.Services.WebApi.Startup))]

namespace App.Services.WebApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // Para obtener más información sobre cómo configurar la aplicación, visite https://go.microsoft.com/fwlink/?LinkID=316888

            var config = GlobalConfiguration.Configuration;

            SecurityTokenConfig.Configure(app, config);
        }
    }
}
