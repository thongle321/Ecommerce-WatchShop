using Ecommerce_WatchShop.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ecommerce_WatchShop.Helper;
namespace DongHo_Admin.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Policy = "Admin")]
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
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var category = _context.Categories.Find(id);
            if (category != null)
            {
                _context.Categories.Remove(category);
                _context.SaveChanges();

                return Json(new { success = true, message = "Xóa danh mục thành công!" });
            }
            return Json(new { success = false, message = "Không tìm thấy danh mục!" });
        }


    }
}
