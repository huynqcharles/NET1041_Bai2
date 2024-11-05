using FromQuery.Models;
using FromQuery.Services;
using Microsoft.AspNetCore.Mvc;

namespace FromQuery.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ProductService _productService = new ProductService();

        [HttpGet]
        public IActionResult Index([FromQuery] ProductQueryParameters queryParameters)
        {
            var products = _productService.GetProducts(queryParameters);
            return View(products);
        }
    }
}
