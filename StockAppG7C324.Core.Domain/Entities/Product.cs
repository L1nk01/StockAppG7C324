using StockAppG7C324.Core.Domain.Common;

namespace StockAppG7C324.Core.Domain.Entities
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
