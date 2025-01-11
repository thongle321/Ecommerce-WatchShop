﻿using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Ecommerce_WatchShop.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using Ecommerce_WatchShop.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using Ecommerce_WatchShop.Abstractions;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.ModelBinding;


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
        var loginVM = new LoginVM();
        return View(loginVM);
    }
    public IActionResult Introduction()
    {
        return View();
    }
    [HttpGet]
    public IActionResult Contact()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Contact(ContactVM contactVM)
    {
        if (ModelState.IsValid)
        {
            var contact = new Contact
            {
                FullName = contactVM.FullName,
                Email = contactVM.Email,
                Subject = contactVM.Subject,
                Note = contactVM.Note
            };

          
            _context.Contacts.Add(contact);
            await _context.SaveChangesAsync();

           
            return RedirectToAction("Index");
        }

        
        return View("Contact", contactVM);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Register(RegisterVM registerVM)
    {
        if (!ModelState.IsValid)
        {
            return PartialView("_RegisterPartial", registerVM);
        }

        var exist = _context.Accounts
            .FirstOrDefault(a => a.Username == registerVM.Username);

        if (exist != null)
        {
            ModelState.AddModelError("Username", "Username đã tồn tại.");
            return PartialView("_RegisterPartial", registerVM);
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
            DisplayName = account.Username
        };

        _context.Customers.Add(customer);
        await _context.SaveChangesAsync();
        TempData["success"] = "Đăng ký thành công";
        return Json(new { redirectToUrl = Url.Action("Index", "Home") });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(LoginVM loginVM)
    {
        if (!ModelState.IsValid)
        {
            return PartialView("_LoginPartial", loginVM);
        }

        var account = await _context.Accounts.FirstOrDefaultAsync(a => a.Username == loginVM.Username);

        if (account == null)
        {
            ModelState.AddModelError("Username", "Tài khoản không tồn tại");
            return PartialView("_LoginPartial", loginVM);
        }

        if (account.Password != loginVM.Password)
        {
            ModelState.AddModelError("Password", "Tài khoản hoặc mật khẩu bị sai");
            return PartialView("_LoginPartial", loginVM);
        }

        if (account.RoleId == 2)
        {
            ModelState.AddModelError("Username", "Không có quyền truy cập");
            return PartialView("_LoginPartial", loginVM);
        }

        var claims = new List<Claim>
        {
            new Claim("AccountId", account.AccountId.ToString())
        };

        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

        var authProperties = new AuthenticationProperties
        {
            IsPersistent = loginVM.RememberMe,
            ExpiresUtc = DateTime.Now.AddDays(5),
        };

        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);

        HttpContext.Session.SetInt32("CustomerId", account.AccountId);
        TempData["success"] = "Đăng nhập thành công";
        return Json(new { redirectToUrl = Url.Action("Index", "Home") });
    }


    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error(int statuscode)
    {
        if (statuscode == 404)
        {
            return View("404");
        }
        else
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });

        }
    }
}