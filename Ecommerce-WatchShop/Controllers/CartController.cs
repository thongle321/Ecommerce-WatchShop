using Ecommerce_WatchShop.Models.ViewModels;
using Ecommerce_WatchShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class CartController : Controller
{
    private readonly DongHoContext _context;

    public CartController(DongHoContext context)
    {
        _context = context;
    }

    public IActionResult Cart(int page = 1, int pageSize = 4)
    {
        if (!User.Identity.IsAuthenticated)
        {
            // Người dùng chưa đăng nhập
            ViewBag.Message = "Giỏ hàng của bạn hiện đang trống!";
            return View(new CartRequest
            {
                CartItems = new List<Cart>(),
                CurrentPage = 1,
                TotalPages = 1
            });
        }

        var customerIdClaim = User.Claims.FirstOrDefault(c => c.Type == "CustomerId");
        int? customerId = customerIdClaim != null ? int.Parse(customerIdClaim.Value) : (int?)null;

        if (customerId == null)
        {
            ViewBag.Message = "Giỏ hàng của bạn hiện đang trống!";
            return View(new CartRequest
            {
                CartItems = new List<Cart>(),
                CurrentPage = 1,
                TotalPages = 1
            });
        }

        // Lấy tất cả các sản phẩm trong giỏ hàng của khách hàng
        var cartItems = _context.Carts
            .Where(c => c.CustomerId == customerId)
            .Include(c => c.Product) // Để lấy thông tin sản phẩm
            .ToList();

        var totalItems = cartItems.Count;
        var totalPages = (int)Math.Ceiling((double)totalItems / pageSize);

        // Lấy sản phẩm cho trang hiện tại
        var paginatedItems = cartItems
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToList();

        var result = new CartRequest
        {
            CartItems = paginatedItems,
            CurrentPage = page,
            TotalPages = totalPages
        };

        // Truyền dữ liệu phân trang ra View
        ViewBag.CurrentPage = page;
        ViewBag.TotalPages = totalPages;

        return View(result);
    }

    public IActionResult AddToCart([FromBody] CartRequest request)
    {
        if (request.Quantity <= 0)
        {
            return BadRequest(new { message = "Số lượng phải lớn hơn 0!" });
        }

        var customerIdClaim = User.Claims.FirstOrDefault(c => c.Type == "CustomerId");
        int? customerId = customerIdClaim != null ? int.Parse(customerIdClaim.Value) : (int?)null;

        if (!User.Identity.IsAuthenticated)
        {
            return Json(new { success = false, message = "Bạn cần đăng nhập để thêm sản phẩm vào giỏ hàng." });
        }

        // Tìm sản phẩm trong cơ sở dữ liệu
        var product = _context.Products.FirstOrDefault(p => p.ProductId == request.ProductId);
        if (product == null)
        {
            return BadRequest(new { message = "Sản phẩm không tồn tại!" });
        }

        if (request.Quantity > product.Quantity)
        {
            return BadRequest(new { message = "Số lượng yêu cầu vượt quá số lượng có sẵn!" });
        }

        // Tìm sản phẩm trong giỏ hàng của khách hàng
        var existingCartItem = _context.Carts.FirstOrDefault(c => c.ProductId == request.ProductId && c.CustomerId == customerId);
        if (existingCartItem != null)
        {
            existingCartItem.Quantity += request.Quantity;
            if (existingCartItem.Quantity > product.Quantity)
            {
                existingCartItem.Quantity = product.Quantity ?? 0;
            }
            _context.Carts.Update(existingCartItem);
        }
        else
        {
            var newCartItem = new Cart
            {
                ProductId = request.ProductId,
                CustomerId = customerId,
                Quantity = request.Quantity,
                Price = (decimal?)product.Price
            };
            _context.Carts.Add(newCartItem);
        }

        _context.SaveChanges();
        return Ok(new { message = "Sản phẩm đã được thêm vào giỏ hàng!" });
    }
    //cập nhật số lượng
    [HttpPost]
    public IActionResult UpdateCart([FromBody] CartRequest request)
    {
        if (request.Quantity <= 0)
        {
            return BadRequest(new { message = "Số lượng phải lớn hơn 0!" });
        }

        var customerIdClaim = User.Claims.FirstOrDefault(c => c.Type == "CustomerId");
        int? customerId = customerIdClaim != null ? int.Parse(customerIdClaim.Value) : (int?)null;

        if (!User.Identity.IsAuthenticated || customerId == null)
        {
            return Json(new { success = false, message = "Bạn cần đăng nhập để chỉnh sửa giỏ hàng." });
        }

        // Tìm sản phẩm trong giỏ hàng của khách hàng
        var existingCartItem = _context.Carts.FirstOrDefault(c => c.ProductId == request.ProductId && c.CustomerId == customerId);
        if (existingCartItem == null)
        {
            return BadRequest(new { message = "Sản phẩm không tồn tại trong giỏ hàng!" });
        }

        // Tìm sản phẩm trong cơ sở dữ liệu để kiểm tra số lượng có sẵn
        var product = _context.Products.FirstOrDefault(p => p.ProductId == request.ProductId);
        if (product == null || request.Quantity > product.Quantity)
        {
            return BadRequest(new { message = "Số lượng yêu cầu vượt quá số lượng có sẵn!" });
        }

        // Cập nhật số lượng trong giỏ hàng
        existingCartItem.Quantity = request.Quantity;
        _context.Carts.Update(existingCartItem);
        _context.SaveChanges();

        return Ok(new { message = "Số lượng sản phẩm trong giỏ hàng đã được cập nhật!" });
    }
    // Xóa hết giỏ hàng
    public IActionResult ClearCart()
    {
        var customerIdClaim = User.Claims.FirstOrDefault(c => c.Type == "CustomerId");
        int? customerId = customerIdClaim != null ? int.Parse(customerIdClaim.Value) : (int?)null;

        if (customerId == null || !User.Identity.IsAuthenticated)
        {
            return Json(new { success = false, message = "Bạn cần đăng nhập để xóa giỏ hàng." });
        }

        // Xóa tất cả các sản phẩm trong giỏ hàng của khách hàng
        var cartItems = _context.Carts.Where(c => c.CustomerId == customerId).ToList();
        _context.Carts.RemoveRange(cartItems);
        _context.SaveChanges();

        return Json(new { success = true, message = "Giỏ hàng đã được xóa thành công." });
    }
    //xóa từng sản phẩm
    [HttpPost]
    public IActionResult RemoveItem(int productId)
    {
        var customerIdClaim = User.Claims.FirstOrDefault(c => c.Type == "CustomerId");
        int? customerId = customerIdClaim != null ? int.Parse(customerIdClaim.Value) : (int?)null;

        if (customerId == null || !User.Identity.IsAuthenticated)
        {
            return Json(new { success = false, message = "Bạn cần đăng nhập để xóa sản phẩm." });
        }

        // Tìm sản phẩm trong giỏ hàng của khách hàng
        var cartItem = _context.Carts.FirstOrDefault(c => c.ProductId == productId && c.CustomerId == customerId);
        if (cartItem != null)
        {
            _context.Carts.Remove(cartItem);
            _context.SaveChanges();
            return Json(new { success = true, message = "Sản phẩm đã được xóa khỏi giỏ hàng." });
        }

        return Json(new { success = false, message = "Sản phẩm không tồn tại trong giỏ hàng." });
    }


    public IActionResult Checkout()
    {
        return View();
    }
}
