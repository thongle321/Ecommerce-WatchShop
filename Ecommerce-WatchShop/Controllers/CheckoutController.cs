﻿using Ecommerce_WatchShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ecommerce_WatchShop.Models.ViewModels;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using Microsoft.AspNetCore.Authorization;
using Ecommerce_WatchShop.Helper;
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
            if (!User.Identity.IsAuthenticated)
            {
                TempData["ShowLoginModal"] = true;
                return RedirectToAction("Index", "Home");
            }
            if(Carts is null || Carts.Count == 0)
            {
                TempData["error"] = "Giỏ hàng của bạn đang trống";
                return RedirectToAction("Cart", "Cart");
            }    
            return View(Carts);
        }
        [HttpPost]
        public async Task<IActionResult> Checkout(CheckoutVM checkoutVM)
        {
            if (ModelState.IsValid)
            {
                var customerIdClaim = HttpContext.User.Claims.SingleOrDefault(c => c.Type == "CustomerId");
                if (customerIdClaim != null && int.TryParse(customerIdClaim.Value, out var customerId))
                {
                    var bill = new Bill
                    {
                        CustomerId = customerId,
                        FullName = checkoutVM.FullName,
                        Phone = checkoutVM.Phone,
                        Email = checkoutVM.Email,
                        Address = checkoutVM.Address,
                        Province = checkoutVM.Province,
                        District = checkoutVM.District,
                        Ward = checkoutVM.Ward,
                        PaymentMethod = checkoutVM.PaymentMethod,
                        Total = checkoutVM.TotalAmount,
                        Status = 1,
                        OrderDate = DateTime.Now
                    };
                    await _context.Database.BeginTransactionAsync();
                    
                    try
                    {
                        await _context.AddAsync(bill);
                        await _context.SaveChangesAsync();

                        var invoices = new List<Invoice>();
                        foreach(var item in Carts)
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
;
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
            return RedirectToAction("Index", "Home");
        }
    }
}
