using MediaCatalogue_API.Models;
using System.Collections.Generic;

namespace MediaCatalogue_API.Tests.Builders
{
    public class MovieTestBuilder
    {
        public int _id { get; set; }
        public List<Actor> _actors { get; set; }
        public List<Crew> _crew { get; set; }
        public Genre _genre { get; set; }
        public string _title { get; set; }
        public string _year { get; set; }

        public MovieTestBuilder()
        {
            _id = 1;

            _actors = new List<Actor>()
            {
                new ActorTestBuilder() { _id = 2, _name = "Robert De Niro" }.Build(),
                new ActorTestBuilder() { _id = 3, _name = "Joe Pesci" }.Build()
            };

            _crew = new List<Crew>()
            {
                new CrewTestBuilder() { _id = 2, _name = "Martin Scorcese", _role = new RoleTestBuilder() { _id = 1, _name = "Director" }.Build() }.Build()
            };

            _genre = new GenreTestBuilder() { _id = 1, _name = "Drama" }.Build();

            _title = "Goodfellas";

            _year = "1980";
        }

        public Movie Build()
        {
            Movie model = new Movie()
            {
                Id = _id,
                Actors = _actors,
                Crew = _crew,
                Genre = _genre,
                Title = _title,
                Year = _year
            };

            return model;
        }
    }
}
