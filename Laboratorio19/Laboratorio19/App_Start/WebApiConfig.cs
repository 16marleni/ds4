using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Laboratorio19
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}", //Quitamos action ya que nos daba error 404 al ejecutar el Lab192 ya que este atributo nos pide especificar si es un get o algo más
                defaults: new { id = RouteParameter.Optional }
            );

            var formatters = GlobalConfiguration.Configuration.Formatters.JsonFormatter;
            formatters.SerializerSettings.ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver();
        }
    }
}
