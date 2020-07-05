
namespace MediaCatalogue_API.Models
{
    public class Role: EntityBase
    {
        public Role() { }

        public Role(string name) { Name = name; }

        public string Name { get; set; }
    }
}