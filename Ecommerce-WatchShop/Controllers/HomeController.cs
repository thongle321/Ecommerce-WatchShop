using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Ecommerce_WatchShop.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using Ecommerce_WatchShop.Models.ViewModels;
using Microsoft.EntityFrameworkCore;


namespace Ecommerce_WatchShop.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly DongHoContext _context;
    public HomeController(ILogger<HomeController> logger, DongHoContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        return View();
    }
    public IActionResult Introduction()
    {
        return View();
    }
    public IActionResult Contact()
    {
        return View();
    }
    public IActionResult Favorite()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Register(RegisterVM registerVM)
    {
        if (!ModelState.IsValid)
        {
            //return PartialView("_RegisterPartial", registerVM);
        }
        var existingUser = _context.Accounts
            .FirstOrDefault(a => a.Username == registerVM.Username);

        if (existingUser != null)
        {
            //ModelState.AddModelError("Username", "Username đã tồn tại.");
            //return PartialView("_RegisterPartial", registerVM);
        }

        var account = new Account
        {
            Username = registerVM.Username,
            Password = registerVM.Password,
            RoleId = 1,
        };

        _context.Accounts.Add(account);
        await _context.SaveChangesAsync();

        var customer = new Customer
        {
            AccountId = account.AccountId,
        };

        _context.Customers.Add(customer);
        await _context.SaveChangesAsync();

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, account.Username),
            new Claim(ClaimTypes.Role, "User")
        };

        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        var authProperties = new AuthenticationProperties
        {
            IsPersistent = true
        };

        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);

        return RedirectToAction("Index");
    }
    [HttpPost]
    public async Task<IActionResult> Login(LoginVM loginVM)
    {
        if (!ModelState.IsValid)
        {
            //return PartialView("_LoginPartial", loginVM);
        }
        var account = await _context.Accounts.FirstOrDefaultAsync(a => a.Username == loginVM.Username);

        if (account == null || account.Password != loginVM.Password)
        {
            TempData["LoginError"] = "Tài khoản hoặc mật khẩu không đúng.";
        }

        var claims = new List<Claim>
        {
        new Claim(ClaimTypes.Name, account.Username),
        new Claim(ClaimTypes.Role, "User")
        };

        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        var authProperties = new AuthenticationProperties
        {
            IsPersistent = true
        };

        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);

        return RedirectToAction("Index", "Home");
    }


    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}