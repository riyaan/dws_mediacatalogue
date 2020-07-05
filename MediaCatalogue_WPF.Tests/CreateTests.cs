using MediaCatalogue_API.Models;
using MediaCatalogue_WPF.Interactors;
using MediaCatalogue_WPF.Models;
using NUnit.Framework;
using System.Collections.Generic;

namespace MediaCatalogue_WPF.Tests
{
    [TestFixture]
    public class CreateTests
    {
        [Test]
        public void WPF_AddMovie_Success()
        {
            SearchInteractor si = new SearchInteractor();
            GenreInteractor gi = new GenreInteractor();
            ActorInteractor ai = new ActorInteractor();
            CrewInteractor ci = new CrewInteractor();

            MovieRequestModel mrm = new MovieRequestModel()
            {
                Actors = new List<string>() { "Tom Berenger", "Charlie Sheen" },
                Director = "Oliver Stone",
                Genre = "War",
                Location = "DVD",
                Title = "Platoon",
                Year = 1986
            };

            MovieInteractor mi = new MovieInteractor(si, gi, ai, ci);
            ResponseModel<Movie> response = mi.AddMovie(mrm);
        }
    }
}
