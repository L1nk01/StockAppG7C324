using StockAppG7C324.Core.Application.Interfaces.Repositories;
using StockAppG7C324.Core.Application.Interfaces.Services;
using StockAppG7C324.Core.Application.ViewModels.Product;
using StockAppG7C324.Core.Domain.Entities;

namespace StockAppG7C324.Core.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ProductViewModel>> GetAllProductViewModels()
        {
            var productList = await _repository.GetProductsAsync();

            return productList.Select(product => new ProductViewModel
            {
                Name = product.Name,
                Description = product.Description,
                Id = product.Id,
                Price = product.Price,
                ImagePath = product.ImagePath
            }).ToList();
        }

        public async Task AddProduct(SaveProductCRUDViewModel spvm)
        {
            Product product = new();

            product.Name = spvm.Name;
            product.Price = spvm.Price;
            product.ImagePath = spvm.ImagePath;
            product.Description = spvm.Description;
            product.CategoryId = spvm.CategoryId;

            await _repository.AddProductAsync(product);
        }

        public async Task<SaveProductCRUDViewModel> GetByIdSaveProductCRUDViewModel(int id)
        {
            var product = await _repository.GetProductByIdAsync(id);

            SaveProductCRUDViewModel spvm = new();

            spvm.Id = id;
            spvm.Name = product.Name;
            spvm.Description = product.Description;
            spvm.ImagePath = product.ImagePath;
            spvm.Price = product.Price;
            spvm.CategoryId = product.CategoryId;

            return spvm;
        }

        public async Task UpdateProduct(SaveProductCRUDViewModel spvm)
        {
            Product product = new();

            product.Id = spvm.Id;
            product.Name = spvm.Name;
            product.Price = spvm.Price;
            product.ImagePath = spvm.ImagePath;
            product.Description = spvm.Description;
            product.CategoryId = spvm.CategoryId;

            await _repository.UpdateProductAsync(product);
        }

        public async Task DeleteProduct(SaveProductCRUDViewModel spvm)
        {
            Product product = new();

            product.Id = spvm.Id;

            await _repository.DeleteProductAsync(product);
        }
    }
}
