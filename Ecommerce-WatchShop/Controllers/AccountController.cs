using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce_WatchShop.Controllers;

public class AccountController : Controller
{

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
        return View();
    }
    public IActionResult Logout()
    {
        HttpContext.SignOutAsync();
        return RedirectToAction("Index", "Home");
    }
}
