
namespace MediaCatalogue_API.Models
{
    public class Actor: EntityBase
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
    }
}