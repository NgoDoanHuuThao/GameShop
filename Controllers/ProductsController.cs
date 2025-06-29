using GameShop.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GameShop.Controllers
{
    public class ProductsController : Controller
    {
        private IProductRepository ProductRepository;

        public ProductsController(IProductRepository productRepository)
        {
            ProductRepository = productRepository;
        }

        public IActionResult Shop()
        {
            return View(ProductRepository.GetAllProducts());
        }

        public IActionResult Detail(int id)
        {
            var product = ProductRepository.GetProductDetail(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        public IActionResult TrendingProducts()
        {
            return View(ProductRepository.GetTrendingProducts());
        }
    }
}
