using System.ComponentModel.DataAnnotations;

namespace Ecommerce_WatchShop.Models.ViewModels
{
    public class CheckoutValidationVM
    {
        public List<CartRequest> CartRequest { get; set; } = new();
        public CheckoutVM CheckoutVM { get; set; } = null!; 
    }
}
