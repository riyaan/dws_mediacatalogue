using MediaCatalogue_API.Models;

namespace MediaCatalogue_API.Tests.Builders
{
    public class GenreTestBuilder
    {
        public int _id { get; set; }
        public string _name { get; set; }

        public GenreTestBuilder()
        {
            _id = 1;
            _name = "Drama";
        }

        public Genre Build()
        {
            Genre model = new Genre()
            {
                Id = _id,
                Name = _name
            };

            return model;
        }
    }
}
