using Autofac;
using Autofac.Integration.WebApi;
using MediaCatalogue_API.DomainServices.Interface;
using MediaCatalogue_API.Factory;
using MediaCatalogue_API.Models;
using MediaCatalogue_API.RepositoryWrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;

namespace MediaCatalogue_API
{
    public class AutofacWebapiConfig
    {
        public static IContainer Container;

        public static void Initialize(HttpConfiguration config)
        {
            Initialize(config, RegisterServices(new ContainerBuilder()));
        }

        public static void Initialize(HttpConfiguration config, IContainer container)
        {
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        private static IContainer RegisterServices(ContainerBuilder builder)
        {
            //Register your Web API controllers.  
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            //builder.RegisterType<DBCustomerEntities>()
            //       .As<DbContext>()
            //       .InstancePerRequest();

            //builder.RegisterType<DbFactory>()
            //       .As<IDbFactory>()
            //       .InstancePerRequest();

            builder.RegisterType(typeof(RepositoryWrapper<Movie>))
                    .As(typeof(IRepositoryWrapper<Movie>))
                    .InstancePerRequest();

            builder.RegisterType(typeof(Factory<Movie>))
                    .As(typeof(IFactory<Movie>))
                    .InstancePerRequest();

            builder.RegisterType(typeof(MovieRepository))
                    .As(typeof(IMovieRepository))
                    .InstancePerRequest();

            //Set the dependency resolver to be Autofac.  
            Container = builder.Build();

            return Container;
        }

    }
}