using System.Collections.Generic;

namespace MediaCatalogue_API.Models
{
    public class Movie: EntityBase
    {        
        private string _title;
        private string _year;
        private List<Actor> _actors;
        private List<Crew> _crew;
        private Genre _genre;

        public Movie() { }

        public Movie(string title, string year, List<Actor> actors, List<Crew> crew, Genre genre)
        {
            _title = title;
            _year = year;
            _actors = actors;
            _crew = crew;
            _genre = genre;
        }

        public string Title
        {
          get { return _title; }
          set { _title = value; }
        }

        public string Year
        {
            get { return _year; }
            set { _year = value; }
        }

        public List<Actor> Actors
        {
            get { return _actors; }
            set { _actors = value; }
        }      

        public List<Crew> Crew
        {
            get { return _crew; }
            set { _crew = value; }
        } 

        public Genre Genre
        {
            get { return _genre; }
            set { _genre = value; }
        }
    }
}