using Ecommerce_WatchShop.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce_WatchShop
{
    public class SeedData
    {
        public static async Task SeedingData(DongHoContext _context)
        {
            await _context.Database.MigrateAsync();
            if (!_context.Brands.Any())
            {
                Brand citizen = new Brand { Name = "Citizen", Contents = null, Slug = "citizen" };
                Brand doxa = new Brand { Name = "Doxa", Contents = null, Slug = "doxa" };
                Brand curnon = new Brand { Name = "Curnon", Contents = null, Slug = "curnon" };
                Brand seiko = new Brand { Name = "Seiko", Contents = null, Slug = "seiko" };

                await _context.Brands.AddRangeAsync(citizen, doxa, curnon, seiko);
                await _context.SaveChangesAsync();

            }
            if (!_context.Categories.Any())
            {

                Category donghoco = new Category { CategoryName = "Đồng hồ cơ", ParentId = null, Slug = "dong-ho-co" };
                Category donghopin = new Category { CategoryName = "Đồng hồ pin", ParentId = null, Slug = "dong-ho-pin" };
                Category donghonangluong = new Category { CategoryName = "Đồng hồ năng lượng mặt trời", ParentId = null, Slug = "dong-ho-nang-luong-mat-troi" };

                await _context.Categories.AddRangeAsync(donghoco, donghopin, donghonangluong);
                await _context.SaveChangesAsync();
            }
            //if (!_context.Suppliers.Any())
            //{
            //    Supplier citizen_supplier = new Supplier { Name = "Công ty Citizen Watch", Phone = "(800) 321-1023", Information = "CÔNG TY CITIZEN WATCH là một nhà sản xuất thực sự với một quy trình sản xuất toàn diện", Address = "6-1-12, Tanashi-cho, Nishi-Tokyo-shi, Tokyo 188-8511, Japan" };
            //    Supplier doxa_supplier = new Supplier { Name = "Công ty Doxa", Phone = "1-520-369 -872", Information = "Thương hiệu đồng hồ Doxa nổi tiếng của Thuỵ Sĩ được ra mắt với công chúng vào năm 1889 bởi một nghệ nhân chế tác đồng hồ trẻ tuổi", Address = "Rue de Zurich 23A, 2500 Biel/Bienne, Switzerland" };
            //    Supplier curnon_supplier = new Supplier { Name = "Công ty Curnon", Phone = "0868889103", Information = "Với những sản phẩm được thiết kế bằng nhiệt huyết, khát khao và khối óc đầy sáng tạo của đội ngũ chính những người trẻ Việt Nam.", Address = "25 Nguyễn Trãi, P.Bến Thành, Quận 1." };
            //    Supplier seiko_supplier = new Supplier { Name = "Công ty Seiko", Phone = "81-3-3563-2111", Information = "Công ty Nhật Bản thành lập vào năm 1881; nổi tiếng trong lĩnh vực sản xuất và mua bán đồng hồ, thiết bị điện tử", Address = "1-8 Nakase, Mihama-ku, Chiba-shi, Chiba 261-8507, Japan" };

            //    await _context.Suppliers.AddRangeAsync(citizen_supplier, doxa_supplier, curnon_supplier, seiko_supplier);
            //    await _context.SaveChangesAsync();
            //}
            if (!_context.Products.Any())
            {
                var donghopin = _context.Categories.FirstOrDefault(c => c.CategoryName == "Đồng hồ pin");
                var donghoco = _context.Categories.FirstOrDefault(c => c.CategoryName == "Đồng hồ cơ");
                var donghonangluong = _context.Categories.FirstOrDefault(c => c.CategoryName == "Đồng hồ năng lượng mặt trời");

                var citizen = _context.Brands.FirstOrDefault(b => b.Name == "Citizen");
                var doxa = _context.Brands.FirstOrDefault(b => b.Name == "Doxa");
                var curnon = _context.Brands.FirstOrDefault(b => b.Name == "Curnon");
                var seiko = _context.Brands.FirstOrDefault(b => b.Name == "Seiko");

                //var citizen_supplier = _context.Suppliers.FirstOrDefault(s => s.Name == "Công ty Citizen Watch");
                //var doxa_supplier = _context.Suppliers.FirstOrDefault(s => s.Name == "Công ty Doxa");
                //var curnon_supplier = _context.Suppliers.FirstOrDefault(s => s.Name == "Công ty Curnon");
                //var seiko_supplier = _context.Suppliers.FirstOrDefault(s => s.Name == "Công ty Seiko");

                await _context.Products.AddRangeAsync(
                    new Product
                    {
                        Image = "Curnon Kashmir.png",
                        ProductName = "Curnon Kashmir",
                        CategoryId = donghoco?.CategoryId,
                        BrandId = curnon?.BrandId,
                        Gender = 1,
                        Price = 2279000,
                        ShortDescription = "Đồng hồ sang trọng dành cho nam",
                        Description = "Đồng hồ nam Curnon Kashmir Classic có thiết kế tối giản, mang phong cách trẻ trung; Dây da, có kim rốn, Mặt kính Sapphire chống trầy xước, Chống nước 3ATM…",
                        Specification = "Kích thước mặt: 40mm<br> Độ dày: 7mm<br> Màu mặt: White<br> Loại máy: MIYOTA QUARTZ<br> Kích cỡ dây: 20mm<br>Chống nước: 3ATM<br> Mặt kính: Sapphire<br> Chất liệu dây: Dây Da Genuine",
                        Quantity = 10,
                        Status = 1,
                        Views = 1000,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = null,
                        Deleted = null,
                        Slug = "curnon-kashmir"
                    },
                    new Product
                    {
                        Image = "Citizen-BI5104-57e.png",
                        ProductName = "Citizen BI5104 57e",
                        CategoryId = donghopin?.CategoryId,
                        BrandId = citizen?.BrandId,
                        Gender = 1,
                        Price = 5280000,
                        ShortDescription = "Citizen BI5104-57E – Nam – Quartz (Pin) – Mặt Số 41mm, Kính Cứng, Chống Nước 5ATM",
                        Description = "Citizen BI5104-57E gây ấn tượng bởi cấu trúc Cushion Lug (vấu đệm) mang đến phong cách thể thao sang trọng. Bộ máy thạch anh in-house đảm bảo thời gian luôn hiển thị chính xác trong khoảng +/- 15 giây mỗi tháng.",
                        Specification = "<b>Đường kính mặt số: </b>41 mm<br><b>Bề dày mặt số: </b>11 mm<br>Niềng: Thép không gỉ<br>Dây đeo: Thép dáng Oyster",
                        Quantity = 12,
                        Status = 1,
                        Views = 50,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = null,
                        Deleted = null,
                        Slug = "citizen-bi5104-57e"
                    },
                    new Product
                    {
                        Image = "Citizen-Tsuyosa.png",
                        ProductName = "Citizen Tsuyosa",
                        CategoryId = donghoco?.CategoryId,
                        BrandId = citizen?.BrandId,
                        Gender = 1,
                        Price = 12485000,
                        ShortDescription = "Citizen Tsuyosa NJ0151-88M – Nam – Kính Sapphire – Mặt Số 40mm",
                        Description = "Citizen Tsuyosa NJ0151-88M mang đến hơi thở tươi mới từ đại dương, theo đuổi phong cách năng động, trẻ trung, kích thước mặt số 40mm phù hợp đa số với quý ông.",
                        Specification = "Thương hiệu: Citizen, Bộ sưu tập: Citizen Tsuyosa, Xuất xứ: Nhật Bản, Kính: Sapphire (Kính chống trầy), Máy: Caliber 8210 Automatic (Cơ tự động), Đường kính mặt số: 40 mm, Bề dày mặt số: 11.7 mm, Niềng: Thép không gỉ, Dây đeo: Thép không gỉ, Chống nước: 5 ATM.",
                        Quantity = 6,
                        Status = 1,
                        Views = 100,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = null,
                        Deleted = null,
                        Slug = "citizen-tsuyosa"
                    },
                    new Product
                    {
                        Image = "Citizen-NH9130-84L.png",
                        ProductName = "Citizen NH9130 84L",
                        CategoryId = donghoco?.CategoryId,
                        BrandId = citizen?.BrandId,
                        Gender = 1,
                        Price = 10085000,
                        ShortDescription = "Citizen NH9130-84L – Nam – Kính Sapphire – Automatic – Trữ Cót 40 Giờ, Họa Tiết Guilloche, Open Heart",
                        Description = "Citizen Automatic NH9130-84L thiết kế Open heart cùng họa tiết Guilloche hoàn toàn mới mang đến diện mạo nam tính, lịch lãm. Trang bị bộ máy cơ Japan Movt trữ cót 40 giờ, tự động lên cót khi đeo liên tục mỗi ngày.",
                        Specification = "Kính: Sapphire (Kính chống trầy), Máy: Automatic (Miyota 8229 trữ cót 40 giờ), Đường kính mặt số: 40 mm, Bề dày mặt số: 10.7 mm, Niềng: Thép không gỉ, Dây Đeo: Thép không gỉ, Chống nước: 5 ATM,Màu mặt số: Xanh dương.",
                        Quantity = 8,
                        Status = 1,
                        Views = 2000,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = null,
                        Deleted = null,
                        Slug = "citizen-nh9130-84l"
                    },
                    new Product
                    {
                        Image = "Citizen-Eco-Drive.png",
                        ProductName = "Citizen Eco Drive",
                        CategoryId = donghopin?.CategoryId,
                        BrandId = citizen?.BrandId,
                        Gender = 0,
                        Price = 7585000,
                        ShortDescription = "Citizen Eco-Drive EM0506-77A – Nữ – Kính Cứng – Eco-Drive (Năng Lượng Ánh Sáng) – Mặt Số 32mm",
                        Description = "Mẫu Citizen Eco-Drive EM0506-77A phiên bản dây đeo tone màu vàng demi, nền mặt số xà cừ với họa tiết Guilloche thẩm mỹ. Mặt số 32mm với trọng lượng vừa phải phù hợp với nữ giới, sử dụng năng lượng mặt trời có tuổi thọ dài giúp tiết kiệm chi phí, cực kỳ trang nhã và thanh lịch.",
                        Specification = "Kính: Mineral Crystal (Kính cứng), Máy: Eco-Drive (Năng lượng ánh sáng), Đường Kính Mặt Số: 32 mm, Bề Dày Mặt Số: 7.6 mm, Niềng: Thép không gỉ, Dây Đeo: Thép không gỉ, Chống Nước: 5 ATM.",
                        Quantity = 11,
                        Status = 1,
                        Views = 500,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = null,
                        Deleted = null,
                        Slug = "citizen-eco-drive"
                    },
                    new Product
                    {
                        Image = "Citizen-EM0863-53D.png",
                        ProductName = "Citizen EM0863-53D",
                        CategoryId = donghonangluong?.CategoryId,
                        BrandId = citizen?.BrandId,
                        Gender = 0,
                        Price = 12685000,
                        ShortDescription = "Citizen EM0863-53D – Nữ – Eco-Drive (Năng Lượng Ánh Sáng) – Mặt Số 25mm, Kính Cứng, Chống Nước 5ATM",
                        Description = "Citizen Silhouette Crystal EM0863-53D thiết kế mạ vàng PVD sang trọng kết hợp những viên đá pha lê tuyển chọn có độ tán sắc cao, lấp lánh thu hút ánh nhìn. Trang bị bộ máy Eco-Drive hoạt động cực kỳ chính xác mà không phải thay pin thường xuyên.",
                        Specification = "Kính: Mineral Crystal (Kính cứng), Máy: Eco-Drive (Năng lượng ánh sáng), Đường kính mặt số: 25 mm, Bề dày mặt số: 7.3 mm, Niềng: Thép không gỉ, Dây đeo: Thép không gỉ, Màu mặt số: Trắng xà cừ, Chống nước: 5 ATM.",
                        Quantity = 17,
                        Status = 1,
                        Views = 250,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = null,
                        Deleted = null,
                        Slug = "citizen-em0863-53d"
                    },
                    new Product
                    {
                        Image = "Doxa-Executive-Slim.png",
                        ProductName = "Doxa Executive Slim",
                        CategoryId = donghopin?.CategoryId,
                        BrandId = doxa?.BrandId,
                        Gender = 1,
                        Price = 23250000,
                        ShortDescription = "Doxa Executive Slim D201RSV – Nam – Kính Sapphire – Quartz (Pin) – Mặt Số 40mm, Swiss Made, Chống Nước 5ATM",
                        Description = "Mẫu Doxa D201RSV vẻ ngoài sang trọng với mẫu vạch số tạo hình mỏng mang lại sự tinh tế dành cho phái mạnh đầy nổi bật khi các chi tiết kim chỉ được phủ tông vàng hồng trẻ trung đầy cuốn hút.",
                        Specification = "Kính: Sapphire (Kính chống trầy),Máy: Quartz (Pin), Đường kính mặt số: 40 mm, Bề dày mặt số: 6.7 mm, Niềng: Thép không gỉ, Dây đeo: Thép không gỉ, Màu mặt số: Trắng, Chống nước: 5 ATM.",
                        Quantity = 20,
                        Status = 1,
                        Views = 5000,
                        CreatedAt = null,
                        UpdatedAt = null,
                        Deleted = null,
                        Slug = "doxa-executive-slim"
                    },
                    new Product
                    {
                        Image = "Doxa-x-Dorian-Ho-Earlymoon.png",
                        ProductName = "Doxa x Dorian Ho Earlymoon",
                        CategoryId = donghopin?.CategoryId,
                        BrandId = doxa?.BrandId,
                        Gender = 1,
                        Price = 2290000,
                        ShortDescription = "Doxa x Dorian Ho Earlymoon D226RGY – Nam – Kính Sapphire – Quartz (Pin) – Mặt số trẻ trung cùng giờ thế giới tiện dụng – Dây vải Nato bền bỉ mạnh mẽ",
                        Description = "Mẫu Doxa D226RGY phiên bản dây vải Nato tone màu xám đen, kết hợp vỏ kim loại mạ vàng hồng, cùng tính năng GMT tiện dụng, tạo nên vẻ ngoài thời trang năng động cho các chàng trong mọi tình huống.",
                        Specification = "Kính: Sapphire (Kính Chống Trầy),Máy: Quartz (Pin), Đường Kính Mặt Số: 42 mm, Bề Dày Mặt Số: 12 mm",
                        Quantity = 9,
                        Status = 1,
                        Views = 4000,
                        CreatedAt = null,
                        UpdatedAt = null,
                        Deleted = null,
                        Slug = "doxa-x-dorian-ho-earlymoon"
                    },
                    new Product
                    {
                        Image = "Doxa-Noble.png",
                        ProductName = "Doxa Noble",
                        CategoryId = donghopin?.CategoryId,
                        BrandId = doxa?.BrandId,
                        Gender = 0,
                        Price = 25030000,
                        ShortDescription = "Doxa Noble D132TWH – Nữ – Kính Sapphire – Quartz (Pin) – Mặt số Rococo cùng 8 viên kim cương tự nhiên – Họa tiết Guilloche phong cách Byzantine",
                        Description = "Mẫu Doxa Noble D132TWH có thiết kế tinh xảo với họa tiết Guilloché, đính 8 viên kim cương, cùng bộ máy Swiss Made, hứa hẹn mang đên phong thái tự tin và sang trọng cho quý cô.",
                        Specification = "Kính: Sapphire (Kính chống trầy), Máy: Quartz (Pin), Đường kính mặt số: 29 mm, Niềng: Thép không gỉ, Dây đeo: Thép không gỉ, Màu mặt số: Trắng, Chống nước: 5 ATM",
                        Quantity = 22,
                        Status = 1,
                        Views = 150,
                        CreatedAt = null,
                        UpdatedAt = null,
                        Deleted = null,
                        Slug = "doxa-noble"
                    },
                    new Product
                    {
                        Image = "Seiko-SSC943P1.png",
                        ProductName = "Seiko Prospex Speedtimer SSC943P1",
                        CategoryId = donghonangluong?.CategoryId,
                        BrandId = seiko?.BrandId,
                        Gender = 1,
                        Price = 23600000,
                        ShortDescription = "Seiko Prospex Speedtimer SSC943P1 là mẫu đồng hồ thể thao sang trọng với chức năng: Chronograph – Tachymeter – Lịch ngày – Kim xăng báo năng lượng còn lại.",
                        Description = "Seiko Prospex Speedtimer SSC943P1 là mẫu đồng hồ bấm giờ thể thao sang trọng, sử dụng pin năng lượng ánh sáng. Thuộc BST Seiko Prospex Speedtimer ra mắt lần đầu tiên năm 1969 – Kỷ nguyên của thời trang, âm nhạc và mô tô thể thao.",
                        Specification = @"
                            <p><strong>Thương Hiệu:</strong> Seiko</p>
                            <p><strong>Số Hiệu Sản Phẩm:</strong> SSC943P1</p>
                            <p><strong>Bộ sưu tập:</strong>Seiko Prospex</a></p>
                            <p><strong>Xuất Xứ:</strong> Nhật Bản</p>
                            <p><strong>Giới Tính:</strong> Nam</p>
                            <p><strong>Kính:</strong> <strong>Kính: </strong>Sapphire (Phủ AR chống chói)</p>
                            <p><strong>Máy:</strong> Solar (Năng Lượng Ánh Sáng) – Caliber V192</p>
                            <p><strong>Bảo Hành Quốc Tế:</strong> 3 năm</p>
                            <p><strong>Bảo Hành Tại Hải Triều:</strong> 5 Năm</p>
                            <p><strong>Đường Kính Mặt Số:</strong> 41.4 mm</p>
                            <p><strong>Bề Dày Mặt Số:</strong> 13 mm</p>
                            <p><strong>Niềng:</strong> Thép không gỉ</p>
                            <p><strong>Dây Đeo:</strong> Dây da chính hãng</p>
                            <p><strong>Màu Mặt Số:</strong> Vàng Champagne</p>
                            <p><strong>Chống Nước: </strong>10 ATM</p>
                        ",
                        Quantity = 10,
                        Status = 1,
                        Views = 999,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = null,
                        Deleted = null,
                        Slug = "seiko-prospex-speedtimer-ssc943p1"

                    }
                );
                await _context.SaveChangesAsync();

                await _context.ProductImages.AddRangeAsync(
                    new ProductImage { ProductId = 1, Image = "Curnon_Kashmir_Silver___Abyss-removebg-preview.jpg" },
                    new ProductImage { ProductId = 1, Image = "Curnon Kashmir.png" },
                    new ProductImage { ProductId = 2, Image = "Citizen-BI5104-57E-2.png" },
                    new ProductImage { ProductId = 2, Image = "Citizen-BI5104-57E-3.png" },
                    new ProductImage { ProductId = 2, Image = "Citizen-Box1-2.png" },
                    new ProductImage { ProductId = 3, Image = "Citizen-Tsuyosa-3.png" },
                    new ProductImage { ProductId = 3, Image = "Citizen-Tsuyosa-2.png" },
                    new ProductImage { ProductId = 4, Image = "Citizen-NH9130-84L-2.png" },
                    new ProductImage { ProductId = 4, Image = "Citizen-NH9130-84L-3.png" },
                    new ProductImage { ProductId = 5, Image = "Citizen-Eco-Drive-2.png" },
                    new ProductImage { ProductId = 5, Image = "Citizen-Eco-Drive-3.png" },
                    new ProductImage { ProductId = 5, Image = "Citizen-Eco-Drive-4.png" },
                    new ProductImage { ProductId = 6, Image = "Citizen-EM0863-53D-2.png" },
                    new ProductImage { ProductId = 6, Image = "Citizen-EM0863-53D-3.png" },
                    new ProductImage { ProductId = 6, Image = "Citizen-EM0863-53D-4.png" },
                    new ProductImage { ProductId = 7, Image = "Doxa-Executive-Slim-2.png" },
                    new ProductImage { ProductId = 7, Image = "Doxa-Executive-Slim-3.png" },
                    new ProductImage { ProductId = 8, Image = "Doxa-x-Dorian-Ho-Earlymoon.png" },
                    new ProductImage { ProductId = 8, Image = "Doxa-x-Dorian-Ho-Earlymoon-2.png" },
                    new ProductImage { ProductId = 9, Image = "Doxa-Noble.png" },
                    new ProductImage { ProductId = 9, Image = "Doxa-Box-2.png" },
                    new ProductImage { ProductId = 10, Image = "Hop-Seiko.png" },
                    new ProductImage { ProductId = 10, Image = "Seiko-SSC943P1-2.png" },
                    new ProductImage { ProductId = 10, Image = "Seiko-SSC943P1-3.png" }
                );
                await _context.SaveChangesAsync();
            }
            if (!_context.Blogs.Any())
            {
                await _context.Blogs.AddRangeAsync(
                new Blog
                {
                    Image = "Blog_1.jpg",
                    Subject = "Hiểu Về Chuyển Động Của Đồng Hồ Cơ",
                    Contents = "Khám phá thế giới phức tạp của chuyển động cơ học và tìm hiểu điều gì làm nên sự khác biệt của chiếc đồng hồ của bạn."
                },
                new Blog
                {
                    Image = "Blog_Meo.jpg",
                    Subject = "Mẹo chăm sóc đồng hồ",
                    Contents = "Học cách chăm sóc đồng hồ của bạn để nó luôn hoạt động chính xác và bền lâu."
                },
                new Blog
                {
                    Image = "Blog_YN.jpg",
                    Subject = "Ý nghĩa của những chiếc đồng hồ đeo tay",
                    Contents = "Đồng hồ đeo tay là một vật dụng vô cùng quen thuộc với cả phái nam lẫn nữ, dù ở bất kì độ tuổi nào."
                },
                new Blog
                {
                    Image = "Blog_PC.jpg",
                    Subject = "Chọn Đồng Hồ Phù Hợp Với Phong Cách Của Bạn",
                    Contents = "Bạn đang tìm kiếm chiếc đồng hồ phù hợp với phong cách cá nhân? Hãy tham khảo những gợi ý dưới đây để chọn một chiếc đồng hồ hoàn hảo cho bạn."
                },
                new Blog
                {
                    Image = "Blog_Hublot.jpg",
                    Subject = "Các Loại Đồng Hồ Cơ Và Cách Chọn Lựa",
                    Contents = "Đồng hồ cơ được chia thành nhiều loại khác nhau. Hãy tìm hiểu các loại đồng hồ cơ phổ biến và cách chọn lựa một chiếc đồng hồ cơ phù hợp với nhu cầu của bạn."
                },
                new Blog
                {
                    Image = "Blog_Co.jpg",
                    Subject = "Top 10 Đồng Hồ Nam Chất Lượng Nhất 2025",
                    Contents = "Khám phá danh sách top 10 mẫu đồng hồ nam chất lượng nhất trong năm 2025. Những chiếc đồng hồ này không chỉ đẹp mắt mà còn sở hữu tính năng vượt trội."
                }
                );
                await _context.SaveChangesAsync();
            }
            if (!_context.BlogImages.Any())
            {
                await _context.BlogImages.AddRangeAsync
                (
                new BlogImage { BlogId = 1, Contents = "Hình ảnh chi tiết về cơ chế đồng hồ cơ", Image = "Blog_1_detail.jpg" },
                new BlogImage { BlogId = 1, Contents = "Hình ảnh bộ máy đồng hồ cơ", Image = "Blog_1_mechanism.jpg" },
                new BlogImage { BlogId = 2, Contents = "Hình ảnh các dụng cụ chăm sóc đồng hồ", Image = "Blog_Meo_tools.jpg" },
                new BlogImage { BlogId = 2, Contents = "Hình ảnh quy trình chăm sóc đồng hồ", Image = "Blog_Meo_process.jpg" },
                new BlogImage { BlogId = 3, Contents = "Hình ảnh đồng hồ đeo tay phổ biến", Image = "Blog_YN_watch.jpg" },
                new BlogImage { BlogId = 3, Contents = "Hình ảnh lịch sử phát triển đồng hồ đeo tay", Image = "Blog_YN_history.jpg" },
                new BlogImage { BlogId = 4, Contents = "Hình ảnh các mẫu đồng hồ phù hợp với phong cách", Image = "Blog_PC_style.jpg" },
                new BlogImage { BlogId = 4, Contents = "Hình ảnh đồng hồ thời trang cho các dịp đặc biệt", Image = "Blog_PC_special.jpg" },
                new BlogImage { BlogId = 5, Contents = "Hình ảnh các loại đồng hồ cơ phổ biến", Image = "Blog_Hublot_types.jpg" },
                new BlogImage { BlogId = 5, Contents = "Hình ảnh chi tiết các bộ phận của đồng hồ cơ", Image = "Blog_Hublot_parts.jpg" },
                new BlogImage { BlogId = 6, Contents = "Hình ảnh các mẫu đồng hồ nam cao cấp", Image = "Blog_Co_men_watch.jpg" },
                new BlogImage { BlogId = 6, Contents = "Hình ảnh đồng hồ nam nổi bật năm 2025", Image = "Blog_Co_2025.jpg" }
                );
                await _context.SaveChangesAsync();
            }

            if (!_context.Footers.Any())
            {
                await _context.Footers.AddRangeAsync(
                    new Footer
                    {
                        Logo = "Logo.png",
                        Description = "ZZZ không chỉ là nơi để mua sắm, mà còn là một nơi để khám phá, tìm hiểu và đắm mình trong thế giới đồng hồ.",
                        Address = "65 Đ. Huỳnh Thúc Kháng, Bến Nghé, Quận 1, Hồ Chí Minh",
                        Email = "contact@zzz.com",
                        Phone = "0123456789",
                        FacebookUrl = "https://www.facebook.com/ZZZWATCHESS/",
                        Status = true
                    }
                );
                await _context.SaveChangesAsync();
            }
            if (!_context.FooterLinks.Any())
            {
                await _context.FooterLinks.AddRangeAsync(
                    new FooterLink { Title = "Giới Thiệu", Url = "/Home/Introduction", GroupId = 1, DisplayOrder = 1, Status = true },
                    new FooterLink { Title = "Liên Hệ", Url = "/Home/Contact", GroupId = 1, DisplayOrder = 2, Status = true },
                    // Nhóm Tài Khoản (GroupId = 2)
                    new FooterLink { Title = "Tài Khoản Của Tôi", Url = "/Account/Index", GroupId = 2, DisplayOrder = 1, Status = true },
                    new FooterLink { Title = "Yêu Thích", Url = "/Account/Favorite", GroupId = 2, DisplayOrder = 2, Status = true },
                    new FooterLink { Title = "Lịch Sử Đơn Hàng", Url = "/Account/Order", GroupId = 2, DisplayOrder = 3, Status = true },
                    // Nhóm Danh Mục (GroupId = 3)
                    new FooterLink { Title = "Đồng Hồ Nam", Url = "/dong-ho-nam", GroupId = 3, DisplayOrder = 1, Status = true },
                    new FooterLink { Title = "Đồng Hồ Nữ", Url = "/dong-ho-nu", GroupId = 3, DisplayOrder = 2, Status = true },
                    new FooterLink { Title = "Đồng Hồ Cơ", Url = "/dong-ho-co", GroupId = 3, DisplayOrder = 3, Status = true },
                    new FooterLink { Title = "Đồng Hồ Pin", Url = "/dong-ho-pin", GroupId = 3, DisplayOrder = 4, Status = true },
                    new FooterLink { Title = "Đồng hồ Điện Tử", Url = "/dong-ho-dien-tu", GroupId = 3, DisplayOrder = 5, Status = true }
                );
                await _context.SaveChangesAsync();
            }

            if (!_context.Sliders.Any())
            {
                await _context.Sliders.AddRangeAsync
                (
                    new Slider { Title = "Đồng Hồ Citizen", Description = "Sản Phẩm Nổi Bật", Image = "/images/ricky-kharawala-Yka2yhGJwjc-unsplash 1.png", Link = "/Product/ProductDetail/2", DisplayOrder = 1, Status = true },
                    new Slider { Title = "Đồng Hồ Citizen-Eco", Description = "Giảm giá đến 15%", Image = "/images/Artboard-1.jpg", Link = "/Product/ProductDetail/5", DisplayOrder = 2, Status = true },
                    new Slider { Title = "Đồng Hồ Doxa", Description = "Biểu tượng của đẳng cấp và phong cách", Image = "/images/default-large.jpg", Link = "/Product/ProductDetail/9", DisplayOrder = 3, Status = true }
                );
                await _context.SaveChangesAsync();
            }

            if (!_context.Abouts.Any())
            {
                await _context.Abouts.AddRangeAsync
                (
                    new About
                    {
                        Content = @"
                        ZZZ WATCH không chỉ là nơi để mua sắm, mà còn là một nơi để khám phá, tìm hiểu và đắm mình trong thế giới đồng hồ.
                        <br />
                        ZZZ WATCH được xây dựng nhằm cung cấp cho khách hàng những sản phẩm đồng hồ đeo tay cao cấp, chất lượng, 
                        chính hãng cam kết mang đến cho khách hàng những mẫu đồng hồ hoàn hảo về cả thiết kế lẫn tính năng 
                        và hoàn thành sứ mệnh “Nơi An Tâm Mua Đồng Hồ Chính Hãng”. Đồng thời chúng tôi cũng hướng đến  những trải nghiệm dễ dàng, 
                        an toàn và nhanh chóng khi mua sắm trực tuyến thông qua hệ thống hỗ trợ thanh toán và vận hành vững mạnh.
                        ",
                        Address = "65 Đ. Huỳnh Thúc Kháng, Bến Nghé, Quận 1, Hồ Chí Minh",
                        Phone = "0306221377",
                        Email = "0306221377@caothang.edu.vn"
                    }
                );
                await _context.SaveChangesAsync();
            }
            if (!_context.Policies.Any())
            {
                await _context.Policies.AddRangeAsync
                (
                    new Policy
                    {
                        Title = "Giao hàng nhanh",
                        Content = @"Chúng tôi cam kết cung cấp dịch vụ giao hàng nhanh chóng và đáng tin cậy. Đơn hàng của bạn sẽ được xử lý và giao trong vòng 1-2 ngày làm việc, tùy thuộc vào địa chỉ giao hàng. 
                                Đặc biệt, đối với các đơn hàng trong khu vực nội thành, chúng tôi sẽ giao trong ngày nếu đơn hàng được đặt trước 12h00. 
                                Mọi chi phí giao hàng sẽ được hiển thị rõ ràng khi bạn thanh toán, và miễn phí vận chuyển cho đơn hàng có giá trị từ [số tiền cụ thể] trở lên. 
                                Chúng tôi luôn nỗ lực mang đến trải nghiệm giao hàng nhanh chóng, tiện lợi và không gây phiền phức cho khách hàng."
                    },
                    new Policy
                    {
                        Title = "Miễn phí giao hàng",
                        Content = @"Cửa hàng sẽ miễn phí giao hàng cho tất cả các đơn hàng trong phạm vi nội thành.
                                Đối với các đơn hàng ở phạm vi ngoài thành phố thì sẽ được tính phí vận chuyển.
                                Thời gian nhận hàng sẽ từ 1-5 ngày tùy vào địa điểm nhận hàng.
                                Cửa hàng sẽ lựa chọn đối tác vận chuyển uy tín để đảm bảo đồng hồ được giao đến khách hàng một cách an toàn và đúng thời gian.
                                Trong quá trình vận chuyển, nếu sản phẩm bị hư hỏng hoặc thất lạc, cửa hàng sẽ chịu trách nhiệm hoàn toàn và có thể gửi lại sản phẩm mới hoặc hoàn tiền cho khách hàng.
                                Chính sách miễn phí giao hàng có thể không áp dụng cho các khu vực vùng sâu, vùng xa hoặc quốc tế, và trong trường hợp này, khách hàng sẽ được thông báo rõ ràng về các chi phí phát sinh."
                    },
                    new Policy
                    {
                        Title = "Cam kết chính hãng",
                        Content = @"Cửa hàng cam kết tất cả đồng hồ bán ra đều là hàng chính hãng, được nhập khẩu hoặc phân phối trực tiếp từ nhà sản xuất hoặc đại lý ủy quyền.
                                Mỗi sản phẩm sẽ đi kèm với các giấy tờ chứng nhận chính hãng, bao gồm sổ bảo hành, hóa đơn mua hàng, và các giấy tờ liên quan khác.
                                Đồng hồ mua tại cửa hàng sẽ được bảo hành theo tiêu chuẩn của nhà sản xuất. Thời gian bảo hành và các dịch vụ đi kèm sẽ được thực hiện tại các trung tâm bảo hành ủy quyền.
                                Nếu khách hàng chứng minh được sản phẩm là hàng giả, cửa hàng cam kết hoàn trả toàn bộ số tiền đã thanh toán và có thể bồi thường thêm tùy theo chính sách cụ thể.
                                Cửa hàng sẽ cung cấp dịch vụ hậu mãi, bao gồm sửa chữa và bảo trì đồng hồ, với cam kết sử dụng linh kiện chính hãng.
                                Cửa hàng có thể áp dụng chính sách đổi trả linh hoạt nếu khách hàng phát hiện sản phẩm có lỗi sản xuất hoặc không đúng với mô tả ban đầu."
                    }
                );
                await _context.SaveChangesAsync();
            }
            if (!_context.Roles.Any())
            {
                await _context.Roles.AddRangeAsync
                (
                    new Role { Type = "User" },
                    new Role { Type = "Admin" }
                );
                await _context.SaveChangesAsync();
            }
            if (!_context.Accounts.Any())
            {
                await _context.Accounts.AddRangeAsync
                (
                    new Account { Username = "admin", Password = "admin", RoleId = 2, },
                    new Account { Username = "user1", Password = "user1", RoleId = 1 },
                    new Account { Username = "user2", Password = "user2", RoleId = 1, },
                    new Account { Username = "user3", Password = "user3", RoleId = 1, },
                    new Account { Username = "user4", Password = "user4", RoleId = 1 },
                    new Account { Username = "user5", Password = "user5", RoleId = 1, },
                    new Account { Username = "user6", Password = "user6", RoleId = 1 },
                    new Account { Username = "user7", Password = "user7", RoleId = 1, },
                    new Account { Username = "user8", Password = "user8", RoleId = 1 },
                    new Account { Username = "user9", Password = "user9", RoleId = 1, },
                    new Account { Username = "user10", Password = "user10", RoleId = 1 }
                );
                await _context.SaveChangesAsync();
            }
            if (!_context.Customers.Any())
            {
                await _context.Customers.AddRangeAsync
                (
                    new Customer { FullName = "Nguyễn Văn A", Phone = "0123456789", Address = "123 Đường ABC, Quận 1", Email = "vana@gmail.com", Dob = DateOnly.ParseExact("1990-01-01", "yyyy-MM-dd"), Gender = true, AccountId = 2, DisplayName = "user1" },

                    new Customer { FullName = "Trần Thị B", Phone = "0987654321", Address = "456 Đường DEF, Quận 2", Email = "btran@gmail.com", Dob = DateOnly.ParseExact("1992-02-02", "yyyy-MM-dd"), Gender = false, AccountId = 3, DisplayName = "user2" },

                    new Customer { FullName = "Lê Văn C", Phone = "0123456780", Address = "789 Đường GHI, Quận 3", Email = "cle@gmail.com", Dob = DateOnly.ParseExact("1988-03-03", "yyyy-MM-dd"), Gender = true, AccountId = 4, DisplayName = "user3" },

                    new Customer { FullName = "Phạm Thị D", Phone = "0987654310", Address = "321 Đường JKL, Quận 4", Email = "dpham@gmail.com", Dob = DateOnly.ParseExact("1985-04-04", "yyyy-MM-dd"), Gender = false, AccountId = 5, DisplayName = "user4" },

                    new Customer { FullName = "Nguyễn Văn E", Phone = "0123456790", Address = "654 Đường MNO, Quận 5", Email = "evan@gmail.com", Dob = DateOnly.ParseExact("1995-05-05", "yyyy-MM-dd"), Gender = true, AccountId = 6, DisplayName = "user5" },

                    new Customer { FullName = "Trần Thị F", Phone = "0987654322", Address = "987 Đường PQR, Quận 6", Email = "ftran@gmail.com", Dob = DateOnly.ParseExact("1990-06-06", "yyyy-MM-dd"), Gender = false, AccountId = 7, DisplayName = "user6" },

                    new Customer { FullName = "Lê Văn G", Phone = "0123456781", Address = "135 Đường STU, Quận 7", Email = "gle@gmail.com", Dob = DateOnly.ParseExact("1982-07-07", "yyyy-MM-dd"), Gender = true, AccountId = 8, DisplayName = "user7" },

                    new Customer { FullName = "Phạm Thị H", Phone = "0987654311", Address = "246 Đường VWX, Quận 8", Email = "hpham@gmail.com", Dob = DateOnly.ParseExact("2000-07-07", "yyyy-MM-dd"), Gender = true, AccountId = 9, DisplayName = "user8" },

                    new Customer { FullName = "Nguyễn Văn I", Phone = "0123456791", Address = "357 Đường YZ, Quận 9", Email = "ivan@gmail.com", Dob = DateOnly.ParseExact("2002-08-30", "yyyy-MM-dd"), Gender = true, AccountId = 10, DisplayName = "user9" },

                    new Customer { FullName = "Trần Thị J", Phone = "0987654323", Address = "468 Đường ABCD, Quận 10", Email = "jtran@gmail.com", Dob = DateOnly.ParseExact("1996-01-11", "yyyy-MM-dd"), Gender = true, AccountId = 11, DisplayName = "user10" }
                );
                await _context.SaveChangesAsync();
            }
            if (!_context.Bills.Any())
            {
                await _context.Bills.AddRangeAsync
                (
                    new Bill { CustomerId = 1, OrderDate = new DateTime(2021, 5, 15), FullName = "Nguyễn Văn A", Phone = "0123456789", Email = "vana@gmail.com", Address = "123 Đường ABC, Quận 1", Province = "TPHCM", District = "Quận 1", Ward = "Phường 1", PaymentMethod = "Momo", Total = 15118000, Status = 2 },

                    new Bill { CustomerId = 2, OrderDate = new DateTime(2021, 6, 20), FullName = "Trần Thị B", Phone = "0987654321", Email = "btran@gmail.com", Address = "456 Đường DEF, Quận 2", Province = "TPHCM", District = "Quận 2", Ward = "Phường 2", PaymentMethod = "COD", Total = 32655000, Status = 2 },

                    new Bill { CustomerId = 3, OrderDate = new DateTime(2022, 1, 10), FullName = "Lê Văn C", Phone = "0123456780", Email = "cle@gmail.com", Address = "789 Đường GHI, Quận 3", Province = "Hà Nội", District = "Quận 3", Ward = "Phường 3", PaymentMethod = "Momo", Total = 32955000, Status = 2 },

                    new Bill { CustomerId = 4, OrderDate = new DateTime(2022, 3, 15), FullName = "Phạm Thị D", Phone = "0987654310", Email = "dpham@gmail.com", Address = "321 Đường JKL, Quận 4", Province = "Đà Nẵng", District = "Quận 4", Ward = "Phường 4", PaymentMethod = "COD", Total = 27830000, Status = 2 },

                    new Bill { CustomerId = 5, OrderDate = new DateTime(2023, 2, 25), FullName = "Nguyễn Văn E", Phone = "0123456790", Email = "evan@gmail.com", Address = "654 Đường MNO, Quận 5", Province = "Hải Phòng", District = "Quận 5", Ward = "Phường 5", PaymentMethod = "Momo", Total = 75090000, Status = 2 },

                    new Bill { CustomerId = 6, OrderDate = new DateTime(2023, 4, 30), FullName = "Trần Thị F", Phone = "0987654322", Email = "ftran@gmail.com", Address = "987 Đường PQR, Quận 6", Province = "TPHCM", District = "Quận 6", Ward = "Phường 6", PaymentMethod = "COD", Total = 51758000, Status = 2 },
                            
                    new Bill { CustomerId = 7, OrderDate = new DateTime(2024, 7, 5), FullName = "Lê Văn G", Phone = "0123456781", Email = "gle@gmail.com", Address = "135 Đường STU, Quận 7", Province = "Hà Nội", District = "Quận 7", Ward = "Phường 7", PaymentMethod = "Momo", Total = 30255000, Status = 2 },

                    new Bill { CustomerId = 8, OrderDate = new DateTime(2024, 9, 10), FullName = "Phạm Thị H", Phone = "0987654311", Email = "hpham@gmail.com", Address = "246 Đường VWX, Quận 8", Province = "Đà Nẵng", District = "Quận 8", Ward = "Phường 8", PaymentMethod = "COD", Total = 7585000, Status = 2 },

                    new Bill { CustomerId = 9, OrderDate = new DateTime(2025, 1, 15), FullName = "Nguyễn Văn I", Phone = "0123456791", Email = "ivan@gmail.com", Address = "357 Đường YZ, Quận 9", Province = "Hải Phòng", District = "Quận 9", Ward = "Phường 9", PaymentMethod = "Momo", Total = 63425000, Status = 2 },

                    new Bill { CustomerId = 10, OrderDate = new DateTime(2025, 3, 20), FullName = "Trần Thị J", Phone = "0987654323", Email = "jtran@gmail.com", Address = "468 Đường ABCD, Quận 10", Province = "TPHCM", District = "Quận 10", Ward = "Phường 10", PaymentMethod = "COD", Total = 11450000, Status = 2 }

                );
                await _context.SaveChangesAsync();
            }
            if (!_context.Invoices.Any())
            {
                await _context.Invoices.AddRangeAsync
                (
                    new Invoice { BillId = 1, ProductId = 1, Price = 2279000, Quantity = 2, Total = 4558000 },

                    new Invoice { BillId = 1, ProductId = 2, Price = 5280000, Quantity = 2, Total = 10560000 },

                    new Invoice { BillId = 2, ProductId = 3, Price = 12485000, Quantity = 1, Total = 12485000 },

                    new Invoice { BillId = 2, ProductId = 4, Price = 10085000, Quantity = 2, Total = 20170000 },

                    new Invoice { BillId = 3, ProductId = 5, Price = 7585000, Quantity = 1, Total = 7585000 },

                    new Invoice { BillId = 3, ProductId = 6, Price = 12685000, Quantity = 2, Total = 25370000 },

                    new Invoice { BillId = 4, ProductId = 7, Price = 23250000, Quantity = 1, Total = 23250000 },

                    new Invoice { BillId = 4, ProductId = 8, Price = 2290000, Quantity = 2, Total = 4580000 },

                    new Invoice { BillId = 5, ProductId = 9, Price = 25030000, Quantity = 3, Total = 75090000 },

                    new Invoice { BillId = 6, ProductId = 10, Price = 23600000, Quantity = 2, Total = 47200000 },

                    new Invoice { BillId = 6, ProductId = 1, Price = 2279000, Quantity = 2, Total = 4558000 },

                    new Invoice { BillId = 7, ProductId = 4, Price = 10085000, Quantity = 3, Total = 30255000 },

                    new Invoice { BillId = 8, ProductId = 5, Price = 7585000, Quantity = 1, Total = 7585000 },

                    new Invoice { BillId = 9, ProductId = 6, Price = 12685000, Quantity = 5, Total = 63425000 },

                    new Invoice { BillId = 10, ProductId = 8, Price = 2290000, Quantity = 5, Total = 11450000 }

                );
                await _context.SaveChangesAsync();
            }
        }

    }
}