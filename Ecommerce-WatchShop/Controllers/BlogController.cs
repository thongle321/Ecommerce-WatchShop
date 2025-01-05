using Microsoft.AspNetCore.Mvc;

namespace Ecommerce_WatchShop.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
