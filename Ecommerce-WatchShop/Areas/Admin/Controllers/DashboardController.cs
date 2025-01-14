using Ecommerce_WatchShop.Models;
using Ecommerce_WatchShop.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DongHo_Admin.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Policy = "Admin")]
    public class DashboardController : Controller
    {
        private readonly DongHoContext _context;
        private readonly IWebHostEnvironment _webhostEnvironment;
        public DashboardController(DongHoContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webhostEnvironment = webHostEnvironment;
        }
        public async Task<IActionResult> Index()
        {
            var footerVM = new FooterVM
            {
                Footer = await _context.Footers.FirstOrDefaultAsync(),
                InformationLinks = await _context.FooterLinks.Where(f => f.GroupId == 1).ToListAsync(),
                AccountLinks = await _context.FooterLinks.Where(f => f.GroupId == 2).ToListAsync(),
                CategoryLinks = await _context.FooterLinks.Where(f => f.GroupId == 3).ToListAsync()
            };
            return View(footerVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Footer footer, IFormFile logoFile)
        {
            if (logoFile != null)
            {
                string uploadsFolder = Path.Combine(_webhostEnvironment.WebRootPath, "Images");
                string uniqueFileName = Guid.NewGuid().ToString() + "_" + logoFile.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    logoFile.CopyTo(fileStream);
                }

                footer.Logo = uniqueFileName;
            }

            if (footer.Id == 0)
                _context.Footers.Add(footer);
            else
            {
                var existingFooter = _context.Footers.Find(footer.Id);
                if (existingFooter != null)
                {
                    existingFooter.Description = footer.Description;
                    existingFooter.Address = footer.Address;
                    existingFooter.FacebookUrl = footer.FacebookUrl;
                    if (!string.IsNullOrEmpty(footer.Logo))
                        existingFooter.Logo = footer.Logo;
                }
            }
            _context.SaveChanges();
            TempData["success"] = "Cập nhật thông tin web thành công!";
            return RedirectToAction("Index");
        }
    }
}
