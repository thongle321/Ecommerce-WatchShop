using Ecommerce_WatchShop.Helper;
using Ecommerce_WatchShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DongHo_Admin.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly DongHoContext _context;
        public CategoryController(DongHoContext context)
        {

            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var categories = await _context.Categories.ToListAsync();
            return View(categories);
        }
        [HttpPost]
        public async Task<IActionResult> Create(Category model)
        {
            // Log model để kiểm tra dữ liệu gửi từ client
            Console.WriteLine($"CategoryName: {model.CategoryName}, ParentId: {model.ParentId}, Slug: {model.Slug}");

            if (ModelState.IsValid)
            {
                model.Slug = SlugHelper.GenerateSlug(model.CategoryName!).ToString();
                _context.Categories.Add(model);

                try
                {
                    await _context.SaveChangesAsync(); // Dùng async để không bị block thread
                    return Json(new { success = true });
                }
                catch (DbUpdateException ex)
                {
                    // Log lỗi và trả về phản hồi lỗi
                    return Json(new { success = false, message = "Có lỗi xảy ra: " + ex.Message });
                }
                catch (Exception ex)
                {
                    // Lỗi chung
                    return Json(new { success = false, message = "Có lỗi xảy ra: " + ex.Message });
                }
            }
            else
            {
                // Log thông báo nếu ModelState không hợp lệ
                return Json(new { success = false, message = "Dữ liệu không hợp lệ!" });
            }
        }




    }
}
