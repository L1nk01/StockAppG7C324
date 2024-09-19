using Application.Services;
using Application.ViewModels;
using Database.Contexts;
using Microsoft.AspNetCore.Mvc;

namespace StockAppG7C324.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductService _productService;

        public ProductController(ApplicationContext dbContext)
        {
            _productService = new(dbContext); 
        }

        public async Task<IActionResult> ProductCRUD()
        {
            return View(await _productService.GetAllProductViewModels());
        }

        public IActionResult CreateProduct()
        {
            return View("SaveProductCRUD", new SaveProductCRUDViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(SaveProductCRUDViewModel spvm)
        {
            if (!ModelState.IsValid)
            {
                return View("SaveProductCRUD", spvm);
            }

            await _productService.AddProduct(spvm);
            return RedirectToRoute(new { controller = "Product", action = "ProductCRUD"});
        }

        public async Task<IActionResult> UpdateProduct(int id)
        {
            return View("SaveProductCRUD", await _productService.GetByIdSaveProductCRUDViewModel(id));
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProduct(SaveProductCRUDViewModel spvm)
        {
            if (!ModelState.IsValid)
            {
                return View("SaveProductCRUD", spvm);
            }

            await _productService.UpdateProduct(spvm);
            return RedirectToRoute(new { controller = "Product", action = "ProductCRUD" });
        }

        public async Task<IActionResult> DeleteProduct(int id)
        {
            return View("DeleteProductCRUD", await _productService.GetByIdSaveProductCRUDViewModel(id));
        }

        [HttpPost]
        public async Task<IActionResult> DeleteProduct(SaveProductCRUDViewModel spvm)
        {
            await _productService.DeleteProduct(spvm);
            return RedirectToRoute(new { controller = "Product", action = "ProductCRUD" });
        }
    }
}
