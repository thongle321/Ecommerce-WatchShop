using Ecommerce_WatchShop.Models.ViewModels;
using Ecommerce_WatchShop.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Globalization;

namespace DongHo_Admin.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Policy = "Admin")]
    public class StatisticalController : Controller
    {
        private readonly DongHoContext _context;

        public StatisticalController(DongHoContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult GetRevenue(DateTime startDate, DateTime endDate)
        {
            var chartData = _context.Bills
                .Join(_context.Invoices,
                    b => b.BillId,
                    i => i.BillId,
                    (b, i) => new RevenueStatisticVM
                    {
                        Date = b.OrderDate.Date, // Chỉ lấy ngày
                        Revenue = i.Quantity * i.Price // Tính doanh thu từng hóa đơn
                    })
                .GroupBy(s => s.Date)
                .Select(group => new RevenueStatisticVM
                {
                    Date = group.Key,
                    Revenue = group.Sum(s => s.Revenue) // Tổng doanh thu theo ngày
                })
                .OrderBy(s => s.Date) // Sắp xếp theo ngày
                .ToList();

            var result = chartData.Select(item => new
            {
                Date = item.Date.ToString("yyyy-MM-dd"), // Chuyển đổi định dạng ngày thành chuỗi
                Revenue = item.Revenue
            }).ToList();

            return Json(result);
        }

    }
}
