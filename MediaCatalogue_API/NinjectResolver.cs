﻿using MediaCatalogue_API.DomainServices.Interface;
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
            kernel.Bind<IRepositoryWrapper<Genre>>().To<RepositoryWrapper<Genre>>().InSingletonScope();
            kernel.Bind<IRepositoryWrapper<Actor>>().To<RepositoryWrapper<Actor>>().InSingletonScope();
            kernel.Bind<IRepositoryWrapper<Crew>>().To<RepositoryWrapper<Crew>>().InSingletonScope();

            kernel.Bind<IFactory<Movie>>().To<Factory<Movie>>().InSingletonScope();
            kernel.Bind<IFactory<Genre>>().To<Factory<Genre>>().InSingletonScope();
            kernel.Bind<IFactory<Actor>>().To<Factory<Actor>>().InSingletonScope();
            kernel.Bind<IFactory<Crew>>().To<Factory<Crew>>().InSingletonScope();

            kernel.Bind<IMovieRepository>().To<MovieRepository>().InSingletonScope();
            kernel.Bind<IGenreRepository>().To<GenreRepository>().InSingletonScope();
            kernel.Bind<IActorRepository>().To<ActorRepository>().InSingletonScope();
            kernel.Bind<ICrewRepository>().To<CrewRepository>().InSingletonScope();

            return kernel;
        }
    }
}