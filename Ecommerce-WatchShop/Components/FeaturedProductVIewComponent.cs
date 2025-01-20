using Ecommerce_WatchShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce_WatchShop.Components
{
    public class FeaturedProductVIewComponent : ViewComponent
    {
        private readonly DongHoContext _context;

        public FeaturedProductVIewComponent(DongHoContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            DateTime cutoffDate = DateTime.Now.AddDays(-30);
            var featureProduct = await _context.Products.Where(p => p.CreatedAt >= cutoffDate).ToListAsync();
            
            return View(featureProduct);
        }
    }
}
