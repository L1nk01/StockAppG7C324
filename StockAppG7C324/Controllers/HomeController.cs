using Application.Services;
using Database.Contexts;
using Microsoft.AspNetCore.Mvc;
using StockAppG7C324.Models;
using System.Diagnostics;

namespace StockAppG7C324.Controllers
{
    public class HomeController : Controller
    {
        private readonly ProductService _productService;

        public HomeController(ApplicationContext dbContext)
        {
            _productService = new(dbContext);
        }

        public async Task<IActionResult> Index()
        {

            return View(await _productService.GetAllProductViewModels());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
