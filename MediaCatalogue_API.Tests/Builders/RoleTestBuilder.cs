using MediaCatalogue_API.Models;

namespace MediaCatalogue_API.Tests.Builders
{
    public class RoleTestBuilder
    {
        public int _id { get; set; }
        public string _name { get; set; }

        public RoleTestBuilder()
        {
            _id = 1;
            _name = "Director";
        }

        public Role Build()
        {
            Role model = new Role()
            {
                Id = _id,
                Name = _name
            };

            return model;
        }
    }
}
