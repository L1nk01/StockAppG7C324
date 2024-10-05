using StockAppG7C324.Core.Domain.Common;

namespace StockAppG7C324.Core.Domain.Entities
{
    public class Category : BaseBasicEntity
    {
        public ICollection<Product>? Products { get; set; } 
    }
}
