using System.Text.RegularExpressions;
using System.Text;
using Ecommerce_WatchShop.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce_WatchShop.Helper
{
    public class SlugHelper
    {
        private static readonly Dictionary<char, char> CharacterMap = new()
        {
            // Lowercase
            {'à', 'a'}, {'á', 'a'}, {'ạ', 'a'}, {'ả', 'a'}, {'ã', 'a'},
            {'â', 'a'}, {'ấ', 'a'}, {'ầ', 'a'}, {'ậ', 'a'}, {'ẩ', 'a'}, {'ẫ', 'a'},
            {'ă', 'a'}, {'ắ', 'a'}, {'ằ', 'a'}, {'ặ', 'a'}, {'ẳ', 'a'}, {'ẵ', 'a'},
            {'è', 'e'}, {'é', 'e'}, {'ẹ', 'e'}, {'ẻ', 'e'}, {'ẽ', 'e'},
            {'ê', 'e'}, {'ế', 'e'}, {'ề', 'e'}, {'ệ', 'e'}, {'ể', 'e'}, {'ễ', 'e'},
            {'ì', 'i'}, {'í', 'i'}, {'ị', 'i'}, {'ỉ', 'i'}, {'ĩ', 'i'},
            {'ò', 'o'}, {'ó', 'o'}, {'ọ', 'o'}, {'ỏ', 'o'}, {'õ', 'o'},
            {'ô', 'o'}, {'ố', 'o'}, {'ồ', 'o'}, {'ộ', 'o'}, {'ổ', 'o'}, {'ỗ', 'o'},
            {'ơ', 'o'}, {'ớ', 'o'}, {'ờ', 'o'}, {'ợ', 'o'}, {'ở', 'o'}, {'ỡ', 'o'},
            {'ù', 'u'}, {'ú', 'u'}, {'ụ', 'u'}, {'ủ', 'u'}, {'ũ', 'u'},
            {'ư', 'u'}, {'ứ', 'u'}, {'ừ', 'u'}, {'ự', 'u'}, {'ử', 'u'}, {'ữ', 'u'},
            {'ỳ', 'y'}, {'ý', 'y'}, {'ỵ', 'y'}, {'ỷ', 'y'}, {'ỹ', 'y'},
            {'đ', 'd'},
            
            // Uppercase
            {'À', 'A'}, {'Á', 'A'}, {'Ạ', 'A'}, {'Ả', 'A'}, {'Ã', 'A'},
            {'Â', 'A'}, {'Ấ', 'A'}, {'Ầ', 'A'}, {'Ậ', 'A'}, {'Ẩ', 'A'}, {'Ẫ', 'A'},
            {'Ă', 'A'}, {'Ắ', 'A'}, {'Ằ', 'A'}, {'Ặ', 'A'}, {'Ẳ', 'A'}, {'Ẵ', 'A'},
            {'È', 'E'}, {'É', 'E'}, {'Ẹ', 'E'}, {'Ẻ', 'E'}, {'Ẽ', 'E'},
            {'Ê', 'E'}, {'Ế', 'E'}, {'Ề', 'E'}, {'Ệ', 'E'}, {'Ể', 'E'}, {'Ễ', 'E'},
            {'Ì', 'I'}, {'Í', 'I'}, {'Ị', 'I'}, {'Ỉ', 'I'}, {'Ĩ', 'I'},
            {'Ò', 'O'}, {'Ó', 'O'}, {'Ọ', 'O'}, {'Ỏ', 'O'}, {'Õ', 'O'},
            {'Ô', 'O'}, {'Ố', 'O'}, {'Ồ', 'O'}, {'Ộ', 'O'}, {'Ổ', 'O'}, {'Ỗ', 'O'},
            {'Ơ', 'O'}, {'Ớ', 'O'}, {'Ờ', 'O'}, {'Ợ', 'O'}, {'Ở', 'O'}, {'Ỡ', 'O'},
            {'Ù', 'U'}, {'Ú', 'U'}, {'Ụ', 'U'}, {'Ủ', 'U'}, {'Ũ', 'U'},
            {'Ư', 'U'}, {'Ứ', 'U'}, {'Ừ', 'U'}, {'Ự', 'U'}, {'Ử', 'U'}, {'Ữ', 'U'},
            {'Ỳ', 'Y'}, {'Ý', 'Y'}, {'Ỵ', 'Y'}, {'Ỷ', 'Y'}, {'Ỹ', 'Y'},
            {'Đ', 'D'}
        };

        public static string GenerateSlug(string phrase)
        {
            if (string.IsNullOrEmpty(phrase))
                return string.Empty;

            // Convert Vietnamese characters to Latin
            string str = ConvertToLatinChars(phrase);
            
            // Convert to lowercase
            str = str.ToLower();
            
            // Remove invalid chars
            str = Regex.Replace(str, @"[^a-z0-9\s-]", "");
            
            // Remove multiple spaces
            str = Regex.Replace(str, @"\s+", " ").Trim();
            
            // Cut and trim
            str = str.Substring(0, str.Length <= 45 ? str.Length : 45).Trim();
            
            // Replace spaces with hyphens
            str = Regex.Replace(str, @"\s", "-");
            
            return str;
        }

        private static string ConvertToLatinChars(string text)
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

            if (string.IsNullOrEmpty(text))
                return string.Empty;

            var result = new StringBuilder(text.Length);
            foreach (char c in text)
            {
                result.Append(CharacterMap.ContainsKey(c) ? CharacterMap[c] : c);
            }
            
            return result.ToString();

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

            if (string.IsNullOrEmpty(name))
                return string.Empty;

            string slug = GenerateSlug(name);
            
            var existingProduct = await context.Products
                .AsNoTracking()
                .Where(p => p.Slug == slug && (productId == null || p.ProductId != productId))
                .FirstOrDefaultAsync();

            if (existingProduct != null)

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