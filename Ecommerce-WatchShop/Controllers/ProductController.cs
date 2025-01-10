using Ecommerce_WatchShop.Models;
using Ecommerce_WatchShop.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Ecommerce_WatchShop.Controllers
{

    public class ProductController : Controller
    {

        private readonly DongHoContext _context;
        public ProductController(DongHoContext context)
        {

            _context = context;
        }

        public IActionResult Product()
        {
            return View();
        }
        [Route("ProductDetail/{id}")]
        public IActionResult ProductDetail(int id)
        {
            var data= _context.Products
                .Include(p => p.Category)
                .Include(p => p.Brand)
                .Include(p => p.Supplier)
                .Include(p => p.ProductImages)
                .Include(p => p.ProductComments)
                .Include(p => p.ProductRatings)
                .FirstOrDefault(p=>p.ProductId==id);
            if (data == null)       
            {
                return NotFound();
            }
            var result = new ProductDetailVM
            {
                Product = data,
                ProductRating = data.ProductRatings
                .Where(r => r.ProductId == id) // Lọc đánh giá theo ProductId
                .Select(r => (double?)r.Rating)  // Chuyển giá trị đánh giá sang nullable double
                .Average() ?? 0,
                TotalRating= data.ProductRatings
                .Where(r => r.ProductId == id)
                .Count()

            };
            return View("ProductDetail", result);
        }
    }
}