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
        public List<string> Director { get; set; }
        public string Genre;
    }
}
