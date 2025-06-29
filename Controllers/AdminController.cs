using GameShop.Data;
using GameShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace GameShop.Controllers
{
    public class AdminController : Controller
    {
        private readonly GameShopDbContext _context;

        public AdminController(GameShopDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(Product product)
        {
            if (!ModelState.IsValid)
                return View(product);

            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            ViewBag.Message = "✅ Đã thêm sản phẩm thành công!";
            return View();
        }
    }
}

