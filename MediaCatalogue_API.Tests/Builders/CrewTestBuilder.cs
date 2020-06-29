using MediaCatalogue_API.Models;

namespace MediaCatalogue_API.Tests.Builders
{
    public class CrewTestBuilder
    {
        public int _id { get; set; }
        public string _name { get; set; }
        public Role _role { get; set; }

        public CrewTestBuilder()
        {
            _id = 1;
            _name = "John Wayne";
            _role = new RoleTestBuilder() { }.Build();
        }

        public Crew Build()
        {
            Crew model = new Crew()
            {
                 Id = _id,
                 Name = _name,
                 Role = _role                  
            };

            return model;
        }
    }
}
