using Microsoft.AspNetCore.Mvc;

namespace Ecommerce_WatchShop.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Cart()
        {
            return View();
        }
    }
}
