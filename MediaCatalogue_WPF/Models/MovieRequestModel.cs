using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaCatalogue_WPF.Models
{
    public class MovieRequestModel
    {
        public string Title { get; set; }
        public int Year { get; set; }
        public string Location { get; set; }   
        
        public List<string> Actors { get; set; }
        public string Director { get; set; }
        public string Genre;

        public UpdateId UpdateId { get; set; }
    }

    public class UpdateId
    {
        public int MovieId { get; set; }
        public Dictionary<int, string> ActorIds { get; set; }
        public int DirectorId { get; set; }
        public int GenreId { get; set; }
    }
}
