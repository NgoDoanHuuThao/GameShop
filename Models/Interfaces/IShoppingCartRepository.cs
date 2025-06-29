namespace GameShop.Models.Interfaces
{
    public interface IShoppingCartRepository
    {
        void AddToCart(Product product);
        int RemoveFromCart(Product product);
        List<ShoppingCartItem> GetAllShoppingCartItems();
        public void ClearCart();
        decimal GetShoppingCartTotal();
        void DecreaseQuantity(int id);

        public List<ShoppingCartItem> ShoppingCartItems { get; set; }
    }
}
