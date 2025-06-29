using System.ComponentModel.DataAnnotations;

namespace GameShop.Models.ViewModels
{
    public class CheckoutViewModel
    {
        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required, Phone]
        public string PhoneNumber { get; set; }

        [Required]
        public string Address { get; set; }
    }
}
