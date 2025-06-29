using System.ComponentModel.DataAnnotations;

namespace GameShop.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string? UserId { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required, Phone]
        public string PhoneNumber { get; set; }

        [Required]
        public string Address { get; set; }

        public DateTime OrderDate { get; set; } = DateTime.Now;

         
        public decimal Total => OrderDetails?.Sum(static d => d.Quantity * d.Price) ?? 0;

        public List<OrderDetail> OrderDetails { get; set; } = new();
    }
    
}
