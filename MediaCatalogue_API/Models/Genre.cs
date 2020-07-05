
namespace MediaCatalogue_API.Models
{
    public class Genre: EntityBase
    {
        public Genre() { }

        public Genre(string name) { Name = name;  }

        public string Name { get; set; }
    }
}