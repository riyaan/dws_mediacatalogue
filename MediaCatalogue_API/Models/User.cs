
namespace MediaCatalogue_API.Models
{
    public class User: EntityBase
    {
        public User() { }

        public User(string name) { Name = name; }

        public string Name { get; set; }
    }
}