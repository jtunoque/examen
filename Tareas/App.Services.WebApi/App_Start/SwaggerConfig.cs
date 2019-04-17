using System.Web.Http;
using WebActivatorEx;
using App.Services.WebApi;
using Swashbuckle.Application;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace App.Services.WebApi
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                    {
                        c.SingleApiVersion("v1", "App.Services.WebApi");


                        // Set this flag to omit descriptions for any actions decorated with the Obsolete attribute
                        c.IgnoreObsoleteActions();

                        // If you annotate Controllers and API Types with
                        // Xml comments (http://msdn.microsoft.com/en-us/library/b2s063f7(v=vs.110).aspx), you can incorporate
                        // those comments into the generated docs and UI. You can enable this by providing the path to one or
                        // more Xml comment files.
                        //
                        c.IncludeXmlComments(string.Format(@"{0}\bin\App.Services.WebApi.XML", System.AppDomain.CurrentDomain.BaseDirectory));

                        // Set this flag to omit schema property descriptions for any type properties decorated with the
                        // Obsolete attribute
                        c.IgnoreObsoleteProperties();

                        // In accordance with the built in JsonSerializer, Swashbuckle will, by default, describe enums as integers.
                        // You can change the serializer behavior by configuring the StringToEnumConverter globally or for a given
                        // enum type. Swashbuckle will honor this change out-of-the-box. However, if you use a different
                        // approach to serialize enums as strings, you can also force Swashbuckle to describe them as strings.
                        //
                        c.DescribeAllEnumsAsStrings();

                    })
                .EnableSwaggerUi();
        }
    }
}
