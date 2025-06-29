namespace GameShop.Models
{
    public class ShoppingCartItem
    {
        internal string? CartId;

        public int Id { get; set; }
        public Product? Product { get; set; }
        public int Quantity { get; set; }
        public string? ShoppingCartId { get; set; }
    }
}
