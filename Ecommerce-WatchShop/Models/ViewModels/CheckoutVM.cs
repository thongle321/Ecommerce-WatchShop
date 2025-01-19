using System.ComponentModel.DataAnnotations;

namespace Ecommerce_WatchShop.Models.ViewModels
{
    public class CheckoutVM
    {
        [Required(ErrorMessage = "Họ và tên là bắt buộc.")]
        [StringLength(200, ErrorMessage = "Họ và tên không được vượt quá 200 ký tự.")]
        public string? FullName { get; set; }

        [Required(ErrorMessage = "Số điện thoại là bắt buộc.")]
        [RegularExpression(@"^0\d{9}$", ErrorMessage = "Số điện thoại phải bắt đầu bằng 0 và có chính xác 10 chữ số.")]
        [StringLength(15)]
        public string? Phone { get; set; }


        [Required(ErrorMessage = "Email là bắt buộc.")]
        [EmailAddress(ErrorMessage = "Email không hợp lệ")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Địa chỉ giao hàng là bắt buộc.")]
        [StringLength(255, ErrorMessage = "Địa chỉ không được vượt quá 255 ký tự.")]
        public string? Address { get; set; }

        [Required(ErrorMessage = "Tỉnh/Thành phố là bắt buộc.")]
        public string? Province { get; set; }

        [Required(ErrorMessage = "Quận/Huyện là bắt buộc.")]
        public string? District { get; set; }

        [Required(ErrorMessage = "Phường/Xã là bắt buộc.")]
        public string? Ward { get; set; }

        [Required(ErrorMessage = "Phương thức thanh toán là bắt buộc.")]
        public string? PaymentMethod { get; set; } 

        public decimal TotalAmount { get; set; } 
    }
}
