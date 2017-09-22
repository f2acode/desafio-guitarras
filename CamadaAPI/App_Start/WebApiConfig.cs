using System.Web.Http;
using System.Web.Http.Cors;

namespace CamadaAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            var politicas = new EnableCorsAttribute(
            origins: "*",
            methods: "*",
            headers: "*"
            );
            config.EnableCors(politicas);

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
