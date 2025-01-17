namespace Ecommerce_WatchShop.Models.ViewModels
{
    public class CartRequest
    {
        public List<Cart> CartItems { get; set; } 
        public int Quantity { get; set; }
        public int ProductId { get; set; }
        public int CurrentPage { get; set; }      
        public int TotalPages { get; set; }
    }
}
