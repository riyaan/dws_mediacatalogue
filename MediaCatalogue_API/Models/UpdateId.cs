using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MediaCatalogue_API.Models
{
    public class UpdateId
    {
        public int MovieId { get; set; }
        public Dictionary<int, string> ActorIds { get; set; }
        public int DirectorId { get; set; }
        public int GenreId { get; set; }
    }
}