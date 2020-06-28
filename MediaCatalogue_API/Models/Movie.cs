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

        private List<Actor> Actors
        {
            get { return _actors; }
            set { _actors = value; }
        }      

        private List<Crew> Crew
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