using Ecommerce_WatchShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ecommerce_WatchShop.Models.ViewModels;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using Microsoft.AspNetCore.Authorization;
using Ecommerce_WatchShop.Helper;
using System.Diagnostics;
namespace Ecommerce_WatchShop.Controllers
{
    public class CheckoutController : Controller
    {
        private readonly DongHoContext _context;
        public List<CartRequest> Carts => CartHelper.GetCart(HttpContext.Session);

        public CheckoutController(DongHoContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            if (!User.Identity!.IsAuthenticated)
            {
                TempData["ShowLoginModal"] = true;
                return RedirectToAction("Index", "Home");
            }
            if(Carts is null || Carts.Count == 0)
            {
                TempData["error"] = "Giỏ hàng của bạn đang trống";
                return RedirectToAction("Cart", "Cart");
            }    
            var checkoutValidationVM = new CheckoutValidationVM
            {
                CheckoutVM = new CheckoutVM(),
                CartRequest = Carts
            };
            return View(checkoutValidationVM);
        }
        [HttpPost]
        public async Task<IActionResult> Checkout(CheckoutValidationVM checkoutValidationVM)
        {
            var carts = Carts;
            if(carts is null && carts.Count == 0)
            {
                TempData["error"] = "Giỏ hàng của bạn đang trống";
                return RedirectToAction("Cart", "Cart");
            }
            if (ModelState.IsValid)
            {
                var customerIdClaim = HttpContext.User.Claims.SingleOrDefault(c => c.Type == "CustomerId");
                if (customerIdClaim != null && int.TryParse(customerIdClaim.Value, out var customerId))
                {
                    var bill = new Bill
                    {
                        CustomerId = customerId,
                        FullName = checkoutValidationVM.CheckoutVM.FullName,
                        Phone = checkoutValidationVM.CheckoutVM.Phone,
                        Email = checkoutValidationVM.CheckoutVM.Email,
                        Address = checkoutValidationVM.CheckoutVM.Address,
                        Province = checkoutValidationVM.CheckoutVM.Province,
                        District = checkoutValidationVM.CheckoutVM.District,
                        Ward = checkoutValidationVM.CheckoutVM.Ward,
                        PaymentMethod = checkoutValidationVM.CheckoutVM.PaymentMethod,
                        Total = (decimal)carts.Sum(item => item.Quantity * item.Price),
                        Status = 1,
                        OrderDate = DateTime.Now
                    };
        
                    await _context.Database.BeginTransactionAsync();
                    
                    try
                    {
                        await _context.AddAsync(bill);
                        await _context.SaveChangesAsync();
        
                        var invoices = new List<Invoice>();
                        foreach(var item in checkoutValidationVM.CartRequest)
                        {
                            var productExists = await _context.Products.AnyAsync(p => p.ProductId == item.ProductId);
                            if (!productExists)
                            {
                                continue; 
                            }
                            invoices.Add(new Invoice
                            {
                                BillId   = bill.BillId,
                                ProductId = item.ProductId,
                                Quantity = item.Quantity,
                                Price = (decimal)item.Price,
                                Total = (decimal)(item.Quantity * item.Price)
                            });
                        }
                        if (invoices.Any())
                        {
                            await _context.AddRangeAsync(invoices);
                            await _context.SaveChangesAsync();
                        }
        
                        await _context.Database.CommitTransactionAsync();
        
                        CartHelper.ClearCart(HttpContext.Session);
                        TempData["success"] = "Đã mua hàng thành công";
                        return RedirectToAction("Index", "Home");
                    }
                    catch
                    {
                        await _context.Database.RollbackTransactionAsync();
                    }
                }    
            }    
            return View("Index", checkoutValidationVM);
        }
    }
}
