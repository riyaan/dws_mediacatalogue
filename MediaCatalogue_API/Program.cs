using MediaCatalogue_API.Controllers;
using MediaCatalogue_API.DomainServices.Interface;
using MediaCatalogue_API.Factory;
using MediaCatalogue_API.Models;
using MediaCatalogue_API.RepositoryWrapper;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;
using System.Web.Http.SelfHost;

namespace MediaCatalogue_API
{
    public class Program
    {
        static void Main(string[] args)
        {
            var config = new HttpSelfHostConfiguration("http://localhost:8000");            

            config.MapHttpAttributeRoutes();

            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.DependencyResolver = new NinjectResolver();

            // Tried using AutoFac
            //Bootstrapper.Run();

            using (HttpSelfHostServer server = new HttpSelfHostServer(config))
            {
                server.OpenAsync().Wait();
                Console.WriteLine("Web API is started.");
                Console.ReadLine();
            }
        }
    }
}