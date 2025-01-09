namespace Ecommerce_WatchShop.Models.ViewModels
{
    public class CustomerVM
    {
        public string? FullName { get; set; }
        public string? DisplayName { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public DateOnly? Dob { get; set; } 
        public bool? Gender { get; set; }
        public string? Address { get; set; }
    }
}
