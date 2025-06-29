using GameShop.Data;
using GameShop.Models;
using GameShop.Models.Services;
using GameShop.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace GameShop.Controllers
{
    public class OrderController : Controller
    {
        private readonly GameShopDbContext _context;
        private readonly ShoppingCartRepository _shoppingCart;
        private readonly UserManager<IdentityUser> _userManager;

        public OrderController(GameShopDbContext context, ShoppingCartRepository shoppingCart, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _shoppingCart = shoppingCart;
            _userManager = userManager;

        }

        [HttpGet]
        public IActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Checkout(CheckoutViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var items = await _shoppingCart.GetCartItemsAsync();
            if (!items.Any())
            {
                ModelState.AddModelError("", "Giỏ hàng trống.");
                return View(model);
            }

            var order = new Order
            {
                UserId = _userManager.GetUserId(User),
                Email = model.Email,
                FullName = model.FullName,
                PhoneNumber = model.PhoneNumber,
                Address = model.Address,
                OrderDetails = new List<OrderDetail>()
            };

            foreach (var item in items)
            {
                if (item is ShoppingCartItem cartItem && cartItem.Product != null)
                {
                    order.OrderDetails.Add(new OrderDetail
                    {
                        ProductId = cartItem.Product.Id,
                        Quantity = cartItem.Quantity,
                        Price = cartItem.Product.Price
                    });
                }
                else
                {
                    ModelState.AddModelError("", "Invalid cart item.");
                    return View(model);
                }
            }

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            await _shoppingCart.ClearCartAsync();

            return RedirectToAction("Confirmation");
        }

        public IActionResult Confirmation()
        {
            return View();
        }
    }
}
