using Ecommerce_WatchShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ecommerce_WatchShop.Models.ViewModels;
namespace Ecommerce_WatchShop.Controllers
{
    public class CheckoutController : Controller
    {
        private readonly DongHoContext _context;

        public CheckoutController(DongHoContext context)
        {
            _context = context;
        }
        public IActionResult Checkout()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }

            var customerIdClaim = User.Claims.FirstOrDefault(c => c.Type == "CustomerId");
            int? customerId = customerIdClaim != null ? int.Parse(customerIdClaim.Value) : (int?)null;

            if (customerId == null)
            {
                return RedirectToAction("Cart", "Cart");
            }

            var cartItems = _context.Carts
                .Where(c => c.CustomerId == customerId)
                .Include(c => c.Product) // Load product details
                .ToList();

            var viewModel = new CheckoutVM
            {
                CartItems = cartItems,
                TotalAmount = (decimal)cartItems.Sum(c => c.Quantity * (c.Product.Price ?? 0))
            };

            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Checkout(CheckoutVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var customerIdClaim = User.Claims.FirstOrDefault(c => c.Type == "CustomerId");
            int? customerId = customerIdClaim != null ? int.Parse(customerIdClaim.Value) : (int?)null;

            if (customerId == null)
            {
                return BadRequest("Không tìm thấy khách hàng.");
            }

            var bill = new Bill
            {
                CustomerId = customerId.Value,
                OrderDate = DateTime.Now,
                FullName = model.FullName,
                Phone = model.Phone,
                Address = model.Address,
                Province = model.Province,
                District = model.District,
                Ward = model.Ward,
                PaymentMethod = model.PaymentMethod,
                Total = model.TotalAmount,
                Status = 0 // 0: Chờ xử lý
            };

            _context.Bills.Add(bill);
            _context.SaveChanges();

            foreach (var item in model.CartItems)
            {
                var invoice = new Invoice
                {
                    BillId = bill.BillId,
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    Price = (decimal)(item.Product.Price ?? 0),
                    Total = (decimal)(item.Quantity * (item.Product.Price ?? 0))
                };

                _context.Invoices.Add(invoice);
            }

            _context.SaveChanges();

            // Xóa giỏ hàng
            var cartItems = _context.Carts.Where(c => c.CustomerId == customerId).ToList();
            _context.Carts.RemoveRange(cartItems);
            _context.SaveChanges();

            return RedirectToAction("Success");
        }

    }
}
