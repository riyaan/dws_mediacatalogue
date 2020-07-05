
namespace MediaCatalogue_API.Models
{
    public class Actor: EntityBase
    {
        public Actor() { }

        public Actor(string name) { Name = name; }

        public string Name { get; set; }
    }
}