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
            string[] arr1 = new[] { "á", "à", "ả", "ã", "ạ", "â", "ấ", "ầ", "ẩ", "ẫ", "ậ", "ă", "ắ", "ằ", "ẳ", "ẵ", "ặ",
                            "đ", "é", "è", "ẻ", "ẽ", "ẹ", "ê", "ế", "ề", "ể", "ễ", "ệ", "í", "ì", "ỉ", "ĩ", "ị",
                            "ó", "ò", "ỏ", "õ", "ọ", "ô", "ố", "ồ", "ổ", "ỗ", "ộ", "ơ", "ớ", "ờ", "ở", "ỡ", "ợ",
                            "ú", "ù", "ủ", "ũ", "ụ", "ư", "ứ", "ừ", "ử", "ữ", "ự", "ý", "ỳ", "ỷ", "ỹ", "ỵ" };
            string[] arr2 = new string[] { "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a",
                                  "d", "e", "e", "e", "e", "e", "e", "e", "e", "e", "e", "e", "e", "e", "i", "i", "i", "i", "i",
                                  "o", "o", "o", "o", "o", "o", "o", "o", "o", "o", "o", "o", "o", "o", "o", "o", "o",
                                  "u", "u", "u", "u", "u", "u", "u", "u", "u", "u", "u", "y", "y", "y", "y", "y" };

            // Thay thế trực tiếp các ký tự có dấu và chữ hoa
            for (int i = 0; i < arr1.Length; i++)
            {
                text = text.Replace(arr1[i], arr2[i]).Replace(arr1[i].ToUpper(), arr2[i].ToUpper());
            }
            return text;
        }


        public enum EntityType
        {
            Product,
            Category
        }

        public static async Task<string> GenerateUniqueSlug(DongHoContext context, string name, EntityType entityType, int? entityId = null)
        {
            // Tạo slug từ tên
            string slug = GenerateSlug(name);

            // Kiểm tra nếu slug đã tồn tại trong cơ sở dữ liệu
            if (entityType == EntityType.Product)
            {
                var existingProduct = await context.Products
                    .AsNoTracking() // Chỉ lấy dữ liệu mà không giữ trạng thái theo dõi
                    .Where(p => p.Slug == slug && (entityId == null || p.ProductId != entityId))
                    .FirstOrDefaultAsync();

                // Nếu có sản phẩm trùng slug, thêm Id vào cuối slug hoặc tạo số đếm duy nhất
                if (existingProduct != null)
                {
                    int counter = 1;
                    string originalSlug = slug;

                    // Kiểm tra và tạo slug duy nhất
                    while (await context.Products.AnyAsync(p => p.Slug == slug && (entityId == null || p.ProductId != entityId)))
                    {
                        slug = $"{originalSlug}-{counter}";
                        counter++;
                    }
                }
            }
            else if (entityType == EntityType.Category)
            {
                var existingCategory = await context.Categories
                    .AsNoTracking() // Chỉ lấy dữ liệu mà không giữ trạng thái theo dõi
                    .Where(c => c.Slug == slug && (entityId == null || c.CategoryId != entityId))
                    .FirstOrDefaultAsync();

                // Nếu có category trùng slug, thêm Id vào cuối slug hoặc tạo số đếm duy nhất
                if (existingCategory != null)
                {
                    int counter = 1;
                    string originalSlug = slug;

                    // Kiểm tra và tạo slug duy nhất
                    while (await context.Categories.AnyAsync(c => c.Slug == slug && (entityId == null || c.CategoryId != entityId)))
                    {
                        slug = $"{originalSlug}-{counter}";
                        counter++;
                    }
                }
            }

            return slug;
        }


    }
}
