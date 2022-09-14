using System.Web.Http;
using System.Web.Http.Cors;

namespace CUSTOMER.BACKEND
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        { 

            // Web API configuration and services
            EnableCorsAttribute cors = new EnableCorsAttribute("*","*","*");
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            config.EnableCors(cors);
        }
    }
}
