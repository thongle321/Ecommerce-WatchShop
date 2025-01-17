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
        [Route("GetRevenue")]
        public IActionResult GetRevenue()
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
        [HttpPost]
        [Route("GetPurchase")]
        public IActionResult GetPurchase()
        {
            var purchaseData = _context.Bills
                .Join(_context.Invoices,
                    b => b.BillId,
                    i => i.BillId,
                    (b, i) => new
                    {
                        Date = b.OrderDate.Date, // Chỉ lấy ngày
                        Quantity = i.Quantity // Số lượng sản phẩm trong hóa đơn
                    })
                .GroupBy(s => s.Date)
                .Select(group => new
                {
                    Date = group.Key,
                    TotalPurchases = group.Sum(s => s.Quantity) // Tổng số lượt mua theo ngày
                })
                .OrderBy(s => s.Date) // Sắp xếp theo ngày
                .ToList();

            var result = purchaseData.Select(item => new
            {
                Date = item.Date.ToString("yyyy-MM-dd"), // Chuyển đổi định dạng ngày thành chuỗi
                TotalPurchases = item.TotalPurchases
            }).ToList();

            return Json(result);
        }
        [HttpPost]
        [Route("SubmitFilterDate")]
        public IActionResult SubmitFilterDate(string filterdate)
        {
            // Kiểm tra và chuyển đổi ngày tháng
            if (!DateTime.TryParse(filterdate, out var parsedDate))
            {
                return BadRequest("Ngày không hợp lệ.");
            }

            try
            {
                // Truy vấn với so sánh DateTime trực tiếp
                var chartData = _context.Bills
                    .Where(b => b.OrderDate.Date == parsedDate.Date) // So sánh trực tiếp
                    .Join(_context.Invoices,
                        b => b.BillId,
                        i => i.BillId,
                        (b, i) => new RevenueStatisticVM
                        {
                            Date = b.OrderDate,
                            Revenue = i.Quantity * i.Price, // Tính doanh thu
                        })
                    .GroupBy(s => s.Date)
                    .Select(group => new RevenueStatisticVM
                    {
                        Date = group.Key,
                        Revenue = group.Sum(s => s.Revenue),
                    })
                    .ToList();

                return Json(chartData);
            }
            catch (Exception ex)
            {
                // Log lỗi
                Console.WriteLine(ex.Message);
                return StatusCode(500, "Đã xảy ra lỗi trong quá trình xử lý.");
            }
        }
    }
}
