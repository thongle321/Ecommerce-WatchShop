using Microsoft.AspNetCore.Mvc;

namespace Ecommerce_WatchShop.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Product()
        {
            return View();
        }
        public IActionResult ProductDetail()
        {
            return View();
        }
    }
}
