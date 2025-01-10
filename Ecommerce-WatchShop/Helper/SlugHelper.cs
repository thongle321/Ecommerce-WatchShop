using System.Text.RegularExpressions;
using System.Text;
using Ecommerce_WatchShop.Models;
using Microsoft.EntityFrameworkCore;


namespace Ecommerce_WatchShop.Helper
{
    public class SlugHelper
    {
        public static string GenerateSlug(string phrase)
        {
            string str = RemoveDiacritics(phrase).ToLower();
            str = Regex.Replace(str, @"[^a-z0-9\s-]", ""); // Xóa ký tự đặc biệt
            str = Regex.Replace(str, @"\s+", " ").Trim(); // Xóa khoảng trắng thừa
            str = str.Substring(0, str.Length <= 45 ? str.Length : 45).Trim(); // Giới hạn độ dài
            str = Regex.Replace(str, @"\s", "-"); // Thay khoảng trắng bằng dấu gạch ngang
            return str;
        }

        private static string RemoveDiacritics(string text)
        {
            var normalizedString = text.Normalize(NormalizationForm.FormD);
            var stringBuilder = new StringBuilder();

            foreach (var c in normalizedString)
            {
                var unicodeCategory = System.Globalization.CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != System.Globalization.UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }
            return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
        }

        public static async Task<string> GenerateUniqueSlug(DongHoContext context, string name, int? productId = null)
        {
            // Tạo slug từ tên sản phẩm
            string slug = GenerateSlug(name);

            // Kiểm tra nếu slug đã tồn tại trong cơ sở dữ liệu
            var existingProduct = await context.Products
                .AsNoTracking() // Chỉ lấy dữ liệu mà không giữ trạng thái theo dõi
                .Where(p => p.Slug == slug && (productId == null || p.ProductId != productId))
                .FirstOrDefaultAsync();

            // Nếu có sản phẩm trùng slug, thêm Id vào cuối slug
            if (existingProduct != null)
            {
                slug = $"{slug}-{productId}";
            }

            return slug;
        }

    }
}
