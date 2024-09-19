using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database.Contexts;
using Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Repository
{
    public class ProductRepository
    {
        private readonly ApplicationContext _dbContext;

        public ProductRepository(ApplicationContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public async Task AddProductAsync(Product product)
        {
            await _dbContext.Products.AddAsync(product);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateProductAsync(Product product)
        {
            _dbContext.Entry(product).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteProductAsync(Product product)
        {
            _dbContext.Set<Product>().Remove(product);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            return await _dbContext.Set<Product>().ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            var product = await _dbContext.Set<Product>().FindAsync(id);

            if (product == null)
            {
                throw new KeyNotFoundException($"Product with ID {id} not found.");
            }

            return product;
        }
    }
}
