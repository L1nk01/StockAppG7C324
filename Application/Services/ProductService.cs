using Application.Repository;
using Application.ViewModels;
using Database.Contexts;
using Database.Entities;

namespace Application.Services
{
    public class ProductService
    {
        private readonly ProductRepository _productRepository;

        public ProductService(ApplicationContext dbContext)
        {
            _productRepository = new(dbContext);
        }

        public async Task<List<ProductViewModel>> GetAllProductViewModels()
        {
            var productList = await _productRepository.GetProductsAsync();

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

            await _productRepository.AddProductAsync(product);
        }

        public async Task<SaveProductCRUDViewModel> GetByIdSaveProductCRUDViewModel(int id)
        {
            var product = await _productRepository.GetProductByIdAsync(id);

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

            await _productRepository.UpdateProductAsync(product);
        }

        public async Task DeleteProduct(SaveProductCRUDViewModel spvm)
        {
            Product product = new();

            product.Id = spvm.Id;

            await _productRepository.DeleteProductAsync(product);
        }
    }
}
