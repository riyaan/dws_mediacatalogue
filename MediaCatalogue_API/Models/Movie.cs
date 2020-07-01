using System.Collections.Generic;

namespace MediaCatalogue_API.Models
{
    public class Movie: EntityBase
    {        
        public Movie() { }

        public Movie(string title, int year, string location, List<Actor> actors, List<Crew> crew, Genre genre)
        {
            Title = title;
            Year = year;
            Location = location;
            Actors = actors;
            Crew = crew;
            Genre = genre;
        }

        public string Title { get; set; }

        public int Year { get; set; }

        public string Location { get; set; }

        public List<Actor> Actors { get; set; }     

        public List<Crew> Crew { get; set; }

        public Genre Genre { get; set; }

    }
}