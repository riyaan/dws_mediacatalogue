
namespace MediaCatalogue_API.Models
{
    public class Crew: EntityBase
    {
        public Crew() { }

        public Crew(string name) { Name = name; }

        public Crew(string name, Role role) { Name = name; Role = role; }

        public string Name { get; set; }

        public Role Role { get; set; }
    }
}