using Ecommerce_WatchShop.Models;
using Ecommerce_WatchShop.Models.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Ecommerce_WatchShop.Controllers;

public class AccountController : Controller
{

    private readonly DongHoContext _context;
    public AccountController(DongHoContext context)
    {

        _context = context;
    }


    public IActionResult AccountDetails()
    {
        ViewBag.Title = "Thông tin cá nhân";
        return View();
    }

    public IActionResult Order()
    {
        ViewBag.Title = "Đơn hàng";
        return View();
    }
    public IActionResult Favorite()
    {
        int? customerId = HttpContext.Session.GetInt32("CustomerId");
        var favoriteProducts = _context.Favorites
            .Include(f => f.Product)
            .Where(f => f.CustomerId == customerId)
            .Select(f => new FavoriteVM
            {
                ProductId = f.Product.ProductId,
                Name = f.Product.ProductName!,
                Price = f.Product.Price,
                Image = f.Product.Image
            }).ToList();

        return View(favoriteProducts);
    }
    [HttpPost]
    public JsonResult AddToWishlist(int productId)
    {
        // Lấy CustomerId từ session hoặc auth system (nếu đã triển khai)
        int? customerId = HttpContext.Session.GetInt32("CustomerId");

        // Kiểm tra sản phẩm đã tồn tại trong danh sách yêu thích chưa
        var existingWishlist = _context.Favorites
            .FirstOrDefault(w => w.CustomerId == customerId && w.ProductId == productId);

        if (existingWishlist != null)
        {
            return Json(new { success = false, message = "Sản phẩm đã có trong danh sách yêu thích!" });
        }

        // Thêm sản phẩm mới vào danh sách yêu thích
        var wishlist = new Favorite
        {
            CustomerId = customerId,
            ProductId = productId
        };
        _context.Favorites.Add(wishlist);
        _context.SaveChanges();

        return Json(new { success = true, message = "Đã thêm vào danh sách yêu thích!" });
    }
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return RedirectToAction("Index", "Home");
    }
   
}
