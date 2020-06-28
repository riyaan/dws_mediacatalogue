
namespace MediaCatalogue_API.Models
{
    public class User: EntityBase
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
    }
}