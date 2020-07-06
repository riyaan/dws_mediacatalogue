using MediaCatalogue_API.DomainServices.Interface;
using MediaCatalogue_API.Factory;
using MediaCatalogue_API.Models;
using MediaCatalogue_API.RepositoryWrapper;
using MediaCatalogue_API.Tests.Builders;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace MediaCatalogue_API.Tests.DomainServices.Implementation
{
    [TestFixture]    
    public class MovieRepositoryTests
    {
        private Mock<IRepositoryWrapper<Movie>> _repositoryWrapper;
        IFactory<Movie> _factory;

        [SetUp]
        public void SetUp()
        {
            _repositoryWrapper = new Mock<IRepositoryWrapper<Movie>>();
            _factory = new Factory<Movie>();           
        }

        [Test]
        public void AddMovie_Success()
        {
            _repositoryWrapper.Setup(foo => foo.InsertMovie(It.IsAny<Movie>())).Returns(1);

            _repositoryWrapper.Setup(foo => foo.ReadMovieByID(It.IsAny<int>())).Returns(new MovieTestBuilder() { _id = 1 }.Build());

            MovieRepository mr = new MovieRepository(_repositoryWrapper.Object, _factory);

            Movie result = mr.Add("Goodfellas", 1990, "DVD",
                new List<Actor>() { new ActorTestBuilder() { }.Build() }, 
                new List<Crew>() { new CrewTestBuilder() { }.Build() },
                new GenreTestBuilder() { }.Build());

            Assert.AreEqual(1, result.Id);
        }

        [Test]
        public void FindMovie_Success()
        {
            _repositoryWrapper.Setup(foo => foo.ReadAll(It.IsAny<string>()))
                .Returns(new List<Movie>() { new MovieTestBuilder() { _title = "Goodfellas" }.Build() });

            MovieRepository mr = new MovieRepository(_repositoryWrapper.Object, _factory);

            List<Movie> result = mr.Find("Goodfellas");

            Assert.AreEqual("Goodfellas", result[0].Title);
        }

        [Test]
        public void EditMovie_Success()
        {
            _repositoryWrapper.Setup(foo => foo.UpdateMovie(It.IsAny<Movie>())).Returns(1);

            _repositoryWrapper.Setup(foo => foo.ReadMovieByID(It.IsAny<int>())).Returns(new MovieTestBuilder() { _location = "DVD" }.Build());

            MovieRepository mr = new MovieRepository(_repositoryWrapper.Object, _factory);

            Movie result = mr.Edit(new MovieTestBuilder()
            {
                _id = 1, _title = "Goodfellas", _year = 1990, _location = "DVD",
                _actors = new List<Actor>() { new ActorTestBuilder() { }.Build() },
                _crew = new List<Crew>() { new CrewTestBuilder() { }.Build() },
                _genre = new GenreTestBuilder() { }.Build()
            }.Build());

            

            Assert.AreEqual("DVD", result.Location);
        }

        [Test]
        public void DeleteMovie_Success()
        {
            _repositoryWrapper.Setup(foo => foo.Delete(It.IsAny<Movie>())).Returns(true);

            MovieRepository mr = new MovieRepository(_repositoryWrapper.Object, _factory);

            bool result = mr.Delete(1);

            Assert.AreEqual(true, result);
        }
    }
}
