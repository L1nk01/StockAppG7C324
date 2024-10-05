using StockAppG7C324.Core.Domain.Entities;

namespace StockAppG7C324.Core.Application.Interfaces.Repositories
{
    public interface IProductRepository
    {
        Task AddProductAsync(Product product);
        Task DeleteProductAsync(Product product);
        Task<Product> GetProductByIdAsync(int id);
        Task<List<Product>> GetProductsAsync();
        Task UpdateProductAsync(Product product);
    }
}