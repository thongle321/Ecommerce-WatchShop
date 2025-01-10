using Microsoft.AspNetCore.Mvc;
using Ecommerce_WatchShop.Models;
using System.Linq;

namespace Ecommerce_WatchShop.Controllers
{
    public class BlogController : Controller
    {
        private readonly DongHoContext _context;

        public BlogController(DongHoContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var blogs = _context.Blogs.ToList();    
            return View(blogs);
        }
    }
}
