using Ecommerce_WatchShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce_WatchShop.Components

{
    public class BestSellerProductViewComponent :ViewComponent
    {
        private readonly DongHoContext _context;

        public BestSellerProductViewComponent(DongHoContext context)
        {
            _context = context; 
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var bestSellerProduct = await _context.Products.Where(p => p.Views >= 1000).ToListAsync();
            return View(bestSellerProduct);
        }
    }
}
