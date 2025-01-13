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
        //[Route("ProductDetail/{id}")]
        //public IActionResult ProductDetail(int id)
        //{
        //    var data= _context.Products
        //        .Include(p => p.Category)
        //        .Include(p => p.Brand)
        //        .Include(p => p.Supplier)
        //        .Include(p => p.ProductImages)
        //        .Include(p => p.ProductComments)
        //        .Include(p => p.ProductRatings)
        //        .FirstOrDefault(p=>p.ProductId==id);
        //    if (data == null)       
        //    {
        //        return NotFound();
        //    }
        //    var result = new ProductDetailVM
        //    {
        //        Product = data,
        //        ProductRating = data.ProductRatings
        //        .Where(r => r.ProductId == id) // Lọc đánh giá theo ProductId
        //        .Select(r => (double?)r.Rating)  // Chuyển giá trị đánh giá sang nullable double
        //        .Average() ?? 0,
        //        TotalRating= data.ProductRatings
        //        .Where(r => r.ProductId == id)
        //        .Count()

        //    };
        //    return View("ProductDetail", result);
        //}
        [Route("ProductDetail/{id}")]
        public IActionResult ProductDetail(int id)
        {
            var customerIdClaim = User.Claims.FirstOrDefault(c => c.Type == "CustomerId");
            int? customerId = customerIdClaim != null ? int.Parse(customerIdClaim.Value) : (int?)null;
            // Lấy sản phẩm, đánh giá, và bình luận từ cơ sở dữ liệu
            var product = _context.Products
                   .Include(p => p.Category)
                .Include(p => p.Brand)
                .Include(p => p.Supplier)
                .Include(p => p.ProductImages)
                .Include(p => p.ProductComments)
                .Include(p => p.ProductRatings)
                .FirstOrDefault(p => p.ProductId == id);

            if (product == null) // Kiểm tra sản phẩm tồn tại
            {
                return NotFound();
            }
            var customerName = customerId != null
    ? _context.Customers.FirstOrDefault(c => c.CustomerId == customerId)?.FullName ?? "Guest"
    : "Guest";
            // Tạo ViewModel
            var viewModel = new ProductDetailVM
            {

                Product = product,
                ProductRating = product.ProductRatings.Any()
                    ? product.ProductRatings.Average(r => (double)r.Rating!) // Tính trung bình điểm đánh giá
                    : 0,
                TotalRating = product.ProductRatings.Count, // Tổng số đánh giá
                Comments = product.ProductComments
                    .Select(c => new ProductCommentVM
                    {
                        CustomerName = customerName, // Hiển thị tên khách
                        Content = c.Contents,
                        CreatedAt = c.CreatedAt,
                        Rating = product.ProductRatings.FirstOrDefault(r => r.CustomerId == c.CustomerId)?.Rating
                    }).ToList()
            };

            return View(viewModel); // Trả về View
        }
        [HttpPost]
        [Route("ProductDetail/{id}/AddReview")]
        public IActionResult AddReview(int id, string content, int rating)
        {
            // Lấy customerId
            var customerIdClaim = User.Claims.FirstOrDefault(c => c.Type == "CustomerId");
            int customerId = int.Parse(customerIdClaim.Value);
            // Kiểm tra sản phẩm tồn tại
            var product = _context.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }

            // Tạo mới bình luận
            var comment = new ProductComment
            {

                ProductId = id,
                CustomerId = customerId,
                Contents = content,
                CreatedAt = DateTime.Now
            };

            // Tạo mới đánh giá
            var productRating = new ProductRating
            {
                ProductId = id,
                CustomerId = customerId,
                Rating = rating
            };

            // Lưu dữ liệu vào cơ sở dữ liệu
            _context.ProductComments.Add(comment);
            _context.ProductRatings.Add(productRating);
            _context.SaveChanges();

            return RedirectToAction("ProductDetail", new { id }); // Quay lại trang chi tiết sản phẩm
        }


    }
}