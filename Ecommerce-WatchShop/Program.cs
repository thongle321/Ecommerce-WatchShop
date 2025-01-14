using Ecommerce_WatchShop;
using Ecommerce_WatchShop.Abstractions;
using Ecommerce_WatchShop.Helper;
using Ecommerce_WatchShop.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

// Cấu hình dịch vụ
builder.Services.AddControllersWithViews();

// Cấu hình DbContext
builder.Services.AddDbContext<DongHoContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Cấu hình Authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
})
.AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
{
    options.LoginPath = "/Home/Login";
    options.AccessDeniedPath = "/Home/404";
})
.AddCookie("Admin", options =>
{
    options.LoginPath = "/Admin/Account/Login";
    options.AccessDeniedPath = "/Home/404";
});

// Cấu hình Authorization
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Admin", policy =>
        policy.RequireClaim(ClaimTypes.Role, "2").AuthenticationSchemes = new[] { "Admin" });
});

// Cấu hình Session
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

// Cấu hình xử lý lỗi
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
        {
    app.UseDeveloperExceptionPage();
}

app.UseStatusCodePagesWithReExecute("/Home/Error", "?statuscode={0}");

app.UseHttpsRedirection();
app.UseStaticFiles(); // Phục vụ tệp tĩnh

app.UseRouting();

app.UseSession();

app.UseAuthentication(); // Xác thực người dùng
app.UseAuthorization();  // Cấp quyền cho người dùng

// Định tuyến với khu vực (areas)
app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}")
    .RequireAuthorization("Admin");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();//using Ecommerce_WatchShop.Abstractions;
//using Ecommerce_WatchShop.Helper;
//using Ecommerce_WatchShop.Models;
//using Microsoft.AspNetCore.Authentication.Cookies;
//using Microsoft.EntityFrameworkCore;
//using System.Security.Claims;
//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.
//builder.Services.AddControllersWithViews();
//builder.Services.AddDbContext<DongHoContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
////builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
////    .AddCookie();
//builder.Services.AddAuthentication(options =>
//{
//    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme; 
//    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
//    options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
//})
//.AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
//{
//    options.LoginPath = "/Home/Login";
//    options.AccessDeniedPath = "/Home/404";
//})
//.AddCookie("Admin", options =>
// {
//     options.LoginPath = "/Admin/Account/Login";
//     options.AccessDeniedPath = "/Home/404";
// });
//builder.Services.AddAuthorization(options =>
//{
//    options.AddPolicy("Admin", policy => policy.RequireClaim(ClaimTypes.Role, "2").AuthenticationSchemes = new[] {"Admin"});
//});
//builder.Services.AddDistributedMemoryCache();
//builder.Services.AddSession(options =>
//{
//    options.IdleTimeout = TimeSpan.FromMinutes(30);
//    options.Cookie.HttpOnly = true; 
//    options.Cookie.IsEssential = true; 
//});
//builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();

//var app = builder.Build();


//app.UseStatusCodePagesWithReExecute("/Home/Error", "?statuscode={0}");
//// Configure the HTTP request pipeline.
//if (!app.Environment.IsDevelopment())
//{
//    app.UseExceptionHandler("/Home/Error");
//    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//    app.UseHsts();
//}
//app.UseHttpsRedirection();
//app.UseRouting();

//app.UseSession();

//app.UseAuthentication();
//app.UseAuthorization();


//app.MapStaticAssets();


//app.MapControllerRoute(
//    name: "areas",
//    pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}")
//    .RequireAuthorization("Admin")
//    .WithStaticAssets();
//app.MapControllerRoute(
//        name: "default",
//        pattern: "{controller=Home}/{action=Index}/{id?}")
//    .WithStaticAssets();


var context = app.Services.CreateScope().ServiceProvider.GetRequiredService<DongHoContext>();
await SeedData.SeedingData(context);

//app.Run();
