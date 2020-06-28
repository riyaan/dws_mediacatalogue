
namespace MediaCatalogue_API.Models
{
    public class Crew: EntityBase
    {
        private string _name;
        private Role _role;        

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public Role Role
        {
            get { return _role; }
            set { _role = value; }
        }
    }
}