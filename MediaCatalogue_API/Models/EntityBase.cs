
namespace MediaCatalogue_API.Models
{
    public abstract class EntityBase
    {
        int _id;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

    }
}