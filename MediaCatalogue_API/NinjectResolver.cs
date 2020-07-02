using MediaCatalogue_API.DomainServices.Interface;
using MediaCatalogue_API.Factory;
using MediaCatalogue_API.Models;
using MediaCatalogue_API.RepositoryWrapper;
using Ninject;
using Ninject.Extensions.ChildKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;

namespace MediaCatalogue_API
{
    public class NinjectResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectResolver() : this(new StandardKernel())
        {
        }

        public NinjectResolver(IKernel ninjectKernel, bool scope = false)
        {
            kernel = ninjectKernel;
            if (!scope)
            {
                AddBindings(kernel);
            }
        }

        public IDependencyScope BeginScope()
        {
            return new NinjectResolver(AddRequestBindings(new ChildKernel(kernel)), true);
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        public void Dispose()
        {

        }

        private void AddBindings(IKernel kernel)
        {
            // singleton and transient bindings go here
            //kernel.Bind<IMovieRepository>().To<MovieRepository>().InSingletonScope();
            //return kernel;
        }

        private IKernel AddRequestBindings(IKernel kernel)
        {
            kernel.Bind<IRepositoryWrapper<Movie>>().To<RepositoryWrapper<Movie>>().InSingletonScope();
            kernel.Bind<IFactory<Movie>>().To<Factory<Movie>>().InSingletonScope();
            kernel.Bind<IMovieRepository>().To<MovieRepository>().InSingletonScope();

            return kernel;
        }
    }
}