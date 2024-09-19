using Database.Common;

namespace Database.Entities
{
    public class Category : BaseBasicEntity
    {
        public ICollection<Product>? Products { get; set; } 
    }
}
