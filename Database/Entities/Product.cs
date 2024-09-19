using Database.Common;

namespace Database.Entities
{
    public class Product : BaseBasicEntity
    {
        public double Price { get; set; }
        public string ImagePath { get; set; }
        public int CategoryId { get; set; } // FK

        // Navigation property
        public Category? Category { get; set; }
    }
}
