using GameShop.Models.Interfaces;
using GameShop.Models.Services;
using Microsoft.AspNetCore.Mvc;

namespace GameShop.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IShoppingCartRepository _shoppingCart;
        private readonly IProductRepository _productRepository;

        public ShoppingCartController(IShoppingCartRepository shoppingCart, IProductRepository productRepository)
        {
            _shoppingCart = shoppingCart;
            _productRepository = productRepository;
        }

        public IActionResult Index()
        {
            var items = _shoppingCart.GetAllShoppingCartItems();
            var total = _shoppingCart.GetShoppingCartTotal();

            ViewBag.Total = total;
            return View(items);
        }

        public RedirectToActionResult AddToCart(int id, [FromServices] IProductRepository productRepo)
        {
            var product = productRepo.GetProductById(id);
            if (product != null)
            {
                _shoppingCart.AddToCart(product);
            }

            return RedirectToAction("Index");
        }

        public RedirectToActionResult RemoveFromCart(int id, [FromServices] IProductRepository productRepo)
        {
            var product = productRepo.GetProductById(id);
            if (product != null)
            {
                _shoppingCart.RemoveFromCart(product);
            }

            return RedirectToAction("Index");
        }

        public RedirectToActionResult ClearCart()
        {
            _shoppingCart.ClearCart();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult IncreaseQuantity(int id)
        {
            var product = _productRepository.GetProductById(id);
            if (product != null)
            {
                _shoppingCart.AddToCart(product);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult DecreaseQuantity(int id)
        {
            _shoppingCart.DecreaseQuantity(id);
            return RedirectToAction("Index");
        }

    }
}

