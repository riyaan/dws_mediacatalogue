using MediaCatalogue_API.Controllers;
using MediaCatalogue_API.DomainServices.Interface;
using MediaCatalogue_API.Factory;
using MediaCatalogue_API.Models;
using MediaCatalogue_API.RepositoryWrapper;
using MediaCatalogue_API.Tests.Builders;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace MediaCatalogue_API.Tests.Controllers
{
    [TestFixture]
    public class MovieControllerTests
    {
        private Mock<IRepositoryWrapper<Movie>> _repositoryWrapper;
        //private Mock<IFactory<Movie>> _factory;
        IFactory<Movie> _factory;

        [SetUp]
        public void SetUp()
        {
            _repositoryWrapper = new Mock<IRepositoryWrapper<Movie>>();
            //_factory = new Mock<IFactory<Movie>>(); 
            _factory = new Factory<Movie>();           
        }

        [Test]
        public void MovieController_Add_Success()
        {
            _repositoryWrapper.Setup(foo => foo.InsertMovie(It.IsAny<Movie>())).Returns(1);

            RepositoryWrapper<Movie> rw = new RepositoryWrapper<Movie>();
            Factory<Movie> factory = new Factory<Movie>();

            MovieRepository mr = new MovieRepository(rw, factory);

            RepositoryWrapper<Genre> rwG = new RepositoryWrapper<Genre>();
            Factory<Genre> factoryG = new Factory<Genre>();

            GenreRepository gr = new GenreRepository(rwG, factoryG);

            MovieController mc = new MovieController(mr, gr);

            int result = mc.Add(
                new MovieTestBuilder()
                {
                     _actors = new List<Actor>() { new ActorTestBuilder() { _name = "Charlize Theron" }.Build() },
                     _crew = new List<Crew>() { new CrewTestBuilder() { _name = "Gina Prince-Bythewood", _role = new RoleTestBuilder() { _name = "Director" }.Build() }.Build() },
                     _genre = new GenreTestBuilder() { _name = "Fantasy" }.Build(),
                      _location = @"D:\movies\20200704\",
                       _title = "The Old Guard",
                        _year = 2020
                }.Build()
             );

            Assert.AreNotEqual(0, result);
        }

        //[Test]
        //public void FindMovie_Success()
        //{
        //    _repositoryWrapper.Setup(foo => foo.ReadAll(It.IsAny<string>()))
        //        .Returns(new List<Movie>() { new MovieTestBuilder() { _title = "Goodfellas" }.Build() });

        //    MovieRepository mr = new MovieRepository(_repositoryWrapper.Object, _factory);

        //    List<Movie> result = mr.Find("Goodfellas");

        //    Assert.AreEqual("Goodfellas", result[0].Title);
        //}

        //[Test]
        //public void EditMovie_Success()
        //{
        //    _repositoryWrapper.Setup(foo => foo.Update(It.IsAny<Movie>())).Returns(true);

        //    MovieRepository mr = new MovieRepository(_repositoryWrapper.Object, _factory);

        //    bool result = mr.Edit("Goodfellas", 1990, "DVD",
        //        new List<Actor>() { new ActorTestBuilder() { }.Build() },
        //        new List<Crew>() { new CrewTestBuilder() { }.Build() },
        //        new GenreTestBuilder() { }.Build());

        //    Assert.AreEqual(true, result);
        //}

        //[Test]
        //public void DeleteMovie_Success()
        //{
        //    _repositoryWrapper.Setup(foo => foo.Delete(It.IsAny<Movie>())).Returns(true);

        //    MovieRepository mr = new MovieRepository(_repositoryWrapper.Object, _factory);

        //    bool result = mr.Delete(1);

        //    Assert.AreEqual(true, result);
        //}
    }
}
