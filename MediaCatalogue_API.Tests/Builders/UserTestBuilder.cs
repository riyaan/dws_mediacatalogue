using MediaCatalogue_API.Models;

namespace MediaCatalogue_API.Tests.Builders
{
    public class UserTestBuilder
    {
        public int _id { get; set; }
        public string _name { get; set; }

        public UserTestBuilder()
        {
            _id = 1;
            _name = "moviecritic82";
        }

        public User Build()
        {
            User model = new User()
            {
                Id = _id,
                Name = _name
            };

            return model;
        }
    }
}
