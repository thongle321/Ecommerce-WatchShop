using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Ecommerce_WatchShop.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using Ecommerce_WatchShop.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using Ecommerce_WatchShop.Abstractions;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;


namespace Ecommerce_WatchShop.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly DongHoContext _context;
    private readonly IPasswordHasher _passwordHasher;

    public HomeController(ILogger<HomeController> logger, DongHoContext context, IPasswordHasher passwordHasher)
    {
        _logger = logger;
        _context = context;
        _passwordHasher = passwordHasher;
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
        var passwordHash = _passwordHasher.Hash(registerVM.Password);

        if (!ModelState.IsValid)
        {
            return PartialView("_RegisterPartial", registerVM);
        }
        var existingUser = _context.Accounts
            .FirstOrDefault(a => a.Username == registerVM.Username);

        if (existingUser != null)
        {
            ModelState.AddModelError("Username", "Username đã tồn tại.");
            return PartialView("_RegisterPartial", registerVM);
        }

        var account = new Account
        {
            Username = registerVM.Username,
            Password = passwordHash,
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
        }
        var account = await _context.Accounts.FirstOrDefaultAsync(a => a.Username == loginVM.Username);

        if (account == null)
        {
        }

        var result = _passwordHasher.Verify(account.Password, loginVM.Password);

        if (!result)
        {
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