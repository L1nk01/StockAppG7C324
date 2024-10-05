using StockAppG7C324.Core.Application.ViewModels.Product;

namespace StockAppG7C324.Core.Application.Interfaces.Services
{
    public interface IProductService
    {
        Task AddProduct(SaveProductCRUDViewModel spvm);
        Task DeleteProduct(SaveProductCRUDViewModel spvm);
        Task<List<ProductViewModel>> GetAllProductViewModels();
        Task<SaveProductCRUDViewModel> GetByIdSaveProductCRUDViewModel(int id);
        Task UpdateProduct(SaveProductCRUDViewModel spvm);
    }
}