using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;

namespace WordChainGame
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
              name: "User",
              routeTemplate: "api/users/{id}",
              defaults: new { controller = "user", id = RouteParameter.Optional }
          );

            config.Routes.MapHttpRoute(
              name: "Topic",
              routeTemplate: "api/topics/{name}/words",
              defaults: new { controller = "Topic" }
          );

            config.Routes.MapHttpRoute(
             name: "Report",
             routeTemplate: "api/report",
             defaults: new { controller = "report" }
         );
        }
    }
}
