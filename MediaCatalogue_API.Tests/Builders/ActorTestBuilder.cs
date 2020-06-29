using MediaCatalogue_API.Models;

namespace MediaCatalogue_API.Tests.Builders
{
    public class ActorTestBuilder
    {
        public int _id { get; set; }
        public string _name { get; set; }

        public ActorTestBuilder()
        {
            _id = 1;
            _name = "John Wayne";
        }

        public Actor Build()
        {
            Actor model = new Actor()
            {
                Id = _id,
                Name = _name
            };

            return model;
        }
    }
}
