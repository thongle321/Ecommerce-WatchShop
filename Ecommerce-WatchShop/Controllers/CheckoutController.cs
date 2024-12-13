using Microsoft.AspNetCore.Mvc;

namespace Ecommerce_WatchShop.Controllers
{
    public class CheckoutController : Controller
    {
        public IActionResult Checkout()
        {
            return View();
        }
    }
}
