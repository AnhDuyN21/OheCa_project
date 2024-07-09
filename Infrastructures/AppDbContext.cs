using Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace Infrastructures
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public  DbSet<AddressToShip> AddressToShips { get; set; }

        public  DbSet<AddressUser> AddressUsers { get; set; }

        public  DbSet<Brand> Brands { get; set; }

        public  DbSet<ChildCategory> ChildCategories { get; set; }

        public  DbSet<Comment> Comments { get; set; }

        public  DbSet<Discount> Discounts { get; set; }

        public  DbSet<Feedback> Feedbacks { get; set; }

        public  DbSet<Image> Images { get; set; }

        public  DbSet<Material> Materials { get; set; }

        public  DbSet<Order> Orders { get; set; }

        public  DbSet<OrderDetail> OrderDetails { get; set; }

        public  DbSet<ParentCategory> ParentCategories { get; set; }

        public  DbSet<Payment> Payments { get; set; }

        public  DbSet<Post> Posts { get; set; }

        public  DbSet<Product> Products { get; set; }

        public  DbSet<ProductMaterial> ProductMaterials { get; set; }

        public  DbSet<ReportOfUser> ReportOfUsers { get; set; }

        public  DbSet<ReportType> ReportTypes { get; set; }

        public  DbSet<Role> Roles { get; set; }

        public  DbSet<ShipCompany> ShipCompanies { get; set; }

        public  DbSet<Shipper> Shippers { get; set; }

        public  DbSet<User> Users { get; set; }

        public  DbSet<Voucher> Vouchers { get; set; }

        public  DbSet<VoucherUsage> VoucherUsages { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region insert data
            //Role
            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 1, Name = "Customer", Description = "Customer", IsDeleted = false },
                new Role { Id = 2, Name = "Admin", Description = "Admin", IsDeleted = false }
                );
            //ParentCategories
            modelBuilder.Entity<ParentCategory>().HasData(
                new ParentCategory { Id = 1, Name = "Thực phẩm chức năng", IsDeleted = false },
                new ParentCategory { Id = 2, Name = "Dược mỹ phẩm", IsDeleted = false },
                new ParentCategory { Id = 3, Name = "Chăm sóc cá nhân", IsDeleted = false },
                new ParentCategory { Id = 4, Name = "Thuốc", IsDeleted = false },
                new ParentCategory { Id = 5, Name = "Thiết bị y tế", IsDeleted = false }
                );
            //ChildCategories
            modelBuilder.Entity<ChildCategory>().HasData(
                //thuốc
                new ChildCategory { Id = 1, Name = "Thuốc kháng sinh, kháng nấm", ParentCategoryId = 4, IsDeleted = false },
                new ChildCategory { Id = 2, Name = "Thuốc điều trị ung thư", ParentCategoryId = 4, IsDeleted = false },
                new ChildCategory { Id = 3, Name = "Thuốc tim mạch và máu", ParentCategoryId = 4, IsDeleted = false },
                new ChildCategory { Id = 4, Name = "Thuốc thần kinh", ParentCategoryId = 4, IsDeleted = false },
                new ChildCategory { Id = 5, Name = "Thuốc tiêu hóa và gan mật", ParentCategoryId = 4, IsDeleted = false },
                //thực phẩm chức năng
                new ChildCategory { Id = 6, Name = "Bổ sung Canxi và vitamin D", ParentCategoryId = 1, IsDeleted = false },
                new ChildCategory { Id = 7, Name = "Vitamin tổng hợp", ParentCategoryId = 1, IsDeleted = false },
                new ChildCategory { Id = 8, Name = "Dầu cá, Omega 3, DHA", ParentCategoryId = 1, IsDeleted = false },
                new ChildCategory { Id = 9, Name = "Vitamind C các loại", ParentCategoryId = 1, IsDeleted = false },
                new ChildCategory { Id = 10, Name = "Bổ sung sắt và Axit Folic", ParentCategoryId = 1, IsDeleted = false },
                new ChildCategory { Id = 11, Name = "Sinh lý nam", ParentCategoryId = 1, IsDeleted = false },
                new ChildCategory { Id = 12, Name = "Sức khỏe tình dục", ParentCategoryId = 1, IsDeleted = false },
                new ChildCategory { Id = 13, Name = "Cân bằng nội tiết tố", ParentCategoryId = 1, IsDeleted = false },
                new ChildCategory { Id = 14, Name = "Sinh lý nữ", ParentCategoryId = 1, IsDeleted = false },
                new ChildCategory { Id = 15, Name = "Hỗ trợ mãn kinh", ParentCategoryId = 1, IsDeleted = false },
                //thiết bị y tế
                new ChildCategory { Id = 16, Name = "Dụng cụ vệ sinh mũi", ParentCategoryId = 5, IsDeleted = false },
                new ChildCategory { Id = 17, Name = "Kim các loại", ParentCategoryId = 5, IsDeleted = false },
                new ChildCategory { Id = 18, Name = "Máy massage", ParentCategoryId = 5, IsDeleted = false },
                new ChildCategory { Id = 19, Name = "Túi chườm", ParentCategoryId = 5, IsDeleted = false },
                new ChildCategory { Id = 20, Name = "Vớ ngăn tĩnh mạch", ParentCategoryId = 5, IsDeleted = false },
                new ChildCategory { Id = 21, Name = "Găng tay", ParentCategoryId = 5, IsDeleted = false },
                new ChildCategory { Id = 22, Name = "Đai lưng", ParentCategoryId = 5, IsDeleted = false },
                new ChildCategory { Id = 23, Name = "Dụng cụ vệ sinh tai", ParentCategoryId = 5, IsDeleted = false },
                new ChildCategory { Id = 24, Name = "Đai nẹp", ParentCategoryId = 5, IsDeleted = false },
                //Chăm sóc cá nhân
                new ChildCategory { Id = 25, Name = "Bao cao su", ParentCategoryId = 3, IsDeleted = false },
                new ChildCategory { Id = 26, Name = "Gel bôi trơn", ParentCategoryId = 3, IsDeleted = false },
                //Dược mỹ phẩm
                new ChildCategory { Id = 27, Name = "Sữa rửa mặt", ParentCategoryId = 2, IsDeleted = false },
                new ChildCategory { Id = 28, Name = "Kem chống nắng", ParentCategoryId = 2, IsDeleted = false },
                new ChildCategory { Id = 29, Name = "Dưỡng da mặt", ParentCategoryId = 2, IsDeleted = false },
                new ChildCategory { Id = 30, Name = "Mặt nạ", ParentCategoryId = 2, IsDeleted = false }
                );
            //matirel
            modelBuilder.Entity<Material>().HasData(
                new Material { Id = 1, Name = "Danh mục", ChildCategoryId = 1, IsDeleted = false },
                new Material { Id = 2, Name = "Dạng bào chế", ChildCategoryId = 1, IsDeleted = false },
                new Material { Id = 3, Name = "Quy cách", ChildCategoryId = 1, IsDeleted = false },
                new Material { Id = 4, Name = "Thành Phần", ChildCategoryId = 1, IsDeleted = false },
                new Material { Id = 5, Name = "Số đăng kí", ChildCategoryId = 1, IsDeleted = false },
                new Material { Id = 6, Name = "Danh mục", ChildCategoryId = 3, IsDeleted = false },
                new Material { Id = 7, Name = "Dạng bào chế", ChildCategoryId = 3, IsDeleted = false },
                new Material { Id = 8, Name = "Quy cách", ChildCategoryId = 3, IsDeleted = false },
                new Material { Id = 9, Name = "Thành phần", ChildCategoryId = 3, IsDeleted = false },
                new Material { Id = 10, Name = "Số đăng kí", ChildCategoryId = 3, IsDeleted = false },
                new Material { Id = 11, Name = "Danh mục", ChildCategoryId = 4, IsDeleted = false },
                new Material { Id = 12, Name = "Dạng bào chế", ChildCategoryId = 4, IsDeleted = false },
                new Material { Id = 13, Name = "Quy cách", ChildCategoryId = 4, IsDeleted = false },
                new Material { Id = 14, Name = "Thành Phần", ChildCategoryId = 4, IsDeleted = false },
                new Material { Id = 15, Name = "Số đăng kí", ChildCategoryId = 4, IsDeleted = false }
                );
            //brand
            modelBuilder.Entity<Brand>().HasData(
                new Brand { Id = 1, Name = "VESTA", IsDeleted = false },
                new Brand { Id = 2, Name = "MEDOPHARM", IsDeleted = false },
                new Brand { Id = 3, Name = "Công ty TNHH Abbott Healthcare Việt Nam", IsDeleted = false },
                new Brand { Id = 4, Name = "TIPHARCO", IsDeleted = false },
                new Brand { Id = 5, Name = "STADA", IsDeleted = false },
                new Brand { Id = 6, Name = "CÔNG TY TNHH DƯỢC THẢO HOÀNG THÀNH", IsDeleted = false },
                new Brand { Id = 7, Name = "CÔNG TY CỔ PHẦN KOREA UNITED PHARM. INT’L", IsDeleted = false },
                new Brand { Id = 8, Name = "DANAPHA", IsDeleted = false },
                new Brand { Id = 9, Name = "CÔNG TY CỔ PHẦN DƯỢC PHẨM GLOMED VIỆT NAM", IsDeleted = false },
                new Brand { Id = 10, Name = "S.C. ANTIBIOTICE S.A", IsDeleted = false },
                new Brand { Id = 11, Name = "US PHARMA", IsDeleted = false },
                new Brand { Id = 12, Name = "CÔNG TY TNHH BRV HEALTHCARE", IsDeleted = false },
                new Brand { Id = 13, Name = "CÔNG TY CP DƯỢC NATURE VIỆT NAM", IsDeleted = false },
                new Brand { Id = 14, Name = "STELLA", IsDeleted = false }
                );
            //Product
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                 Id = 1,
                 Name = "Thuốc Fluconazole Stada 150mg",
                 UnitPrice = 27.500,
                 PriceSold = 25.000,
                 Quantity = 100,
                 QuantitySold = 0,
                 Description = "Fluconazole 150mg là sản phẩm của Công ty TNHH Stada Việt Nam có thành phần chính là Fluconazole có tác dụng điều trị các bệnh nấm Candida tại chỗ và toàn thân, các bệnh nấm do các chủng vi khuẩn khác và dự phòng nhiễm nấm Candida ở bệnh nhân ghép tủy xương đang được hóa trị liệu gây độc tế bào hoặc xạ trị.",
                 BrandId = 5,
                 Country = "Việt Nam",
                 DiscountPercent = 0.1f
                },                
                new Product
                {
                 Id = 2,
                 Name = "Thuốc Hoạt Huyết Trường Phúc",
                 UnitPrice = 104.500,
                 PriceSold = 95.000,
                 Quantity = 100,
                 QuantitySold = 0,
                 Description = "Hoạt Huyết Trường Phúc là sản phẩm của Công ty TNHH Dược Thảo Hoàng Thành có thành phần chính là cao đặc hỗn hợp các dược liệu đương quy, ích mẫu, ngưu tất, thục địa, xích thược, xuyên khung có công dụng điều trị các chứng huyết hư, ứ trệ. Phòng ngừa và điều trị thiểu năng tuần hoàn não (mệt mỏi, đau đầu, chóng mặt, mất thăng bằng, hoa mắt, mất ngủ, suy giảm trí nhớ), thiểu năng tuần hoàn ngoại vi (đau mỏi vai gáy, tê cứng cổ, đau cách hồi, đau cơ, tê bì chân tay), phòng ngừa và hỗ trợ điều trị xơ vữa động mạch, nghẽn mạch, tai biến mạch máo não.",
                 BrandId = 6,
                 Country = "Việt Nam",
                 DiscountPercent = 0.1f
                },
                new Product
                {
                 Id = 3,
                 Name = "Thuốc Ginkokup 40 Korea United",
                 UnitPrice = 165.000,
                 PriceSold = 150.000,
                 Quantity = 100,
                 QuantitySold = 0,
                 Description = "Ginkokup 40 là sản phẩm thuốc của Công ty cổ phần Korea United Pharm. Int' L. - Singapore với thành phần hoạt chất là cao chiết lá bạch quả được chỉ định trong điều trị bệnh sa sút trí tuệ, kể cả bệnh Alzheimer; điều trị các rối loạn mạch máu não, các di chứng sau các tai biến mạch máu não và chấn thương sọ não, hội chứng về não cũng như bị nhức đầu, suy giảm trí nhớ, rối loạn tập trung, suy nhược, chóng mặt; điều trị các bệnh rối loạn tuần hoàn ngoại biên, cải thiện hội chứng Raynaud và điều trị các triệu chứng của bệnh đau cách hồi; điều trị ù tai do mạch máu hoặc do thoái hóa.",
                 BrandId = 7,
                 Country = "Việt Nam",
                 DiscountPercent = 0.1f
                },                
                new Product
                {
                 Id = 4,
                 Name = "Thuốc Dacolfort Danapha",
                 UnitPrice = 85.800,
                 PriceSold = 78.000,
                 Quantity = 100,
                 QuantitySold = 0,
                 Description = "Thuốc Dacolfort được sản xuất bởi Dược Danapha, có thành phần chính là Diosminn và Hesperidin, được chỉ định để điều trị những triệu chứng có liên quan đến suy tĩnh mạch, mạch bạch huyết (nặng chân, đau, chân khó chịu vào buổi sáng). Điều trị các dấu hiệu chức năng có liên quan tới cơn trĩ cấp.",
                 BrandId = 8,
                 Country = "Việt Nam",
                 DiscountPercent = 0.1f
                },               
                new Product
                {
                 Id = 5,
                 Name = "Thuốc Henex 500mg Abbott",
                 UnitPrice = 242.000,
                 PriceSold = 220.000,
                 Quantity = 100,
                 QuantitySold = 0,
                 Description = "Thuốc Henex là sản phẩm của Công ty Cổ phần Dược phẩm Glomed (Abbott) có thành phần chính là phân đoạn flavonoid. Thuốc dùng điều trị các triệu chứng và dấu hiệu của suy tĩnh mạch – mạch bạch huyết vô căn mạn tính ở chi dưới như nặng ở chân, đau chân, phù chân, chuột rút về đêm và chồn chân. Điều trị các triệu chứng của cơn trĩ cấp và bệnh trĩ mạn tính.",
                 BrandId = 9,
                 Country = "Việt Nam",
                 DiscountPercent = 0.1f
                },
                new Product
                {
                 Id = 6,
                 Name = "Thuốc Catavastatin 10mg S.C Antibiotice",
                 UnitPrice = 330.000,
                 PriceSold = 300.000,
                 Quantity = 100,
                 QuantitySold = 0,
                 Description = "Thuốc Catavastatin 10 mg của S.C. ANTIBIOTICE S.A, thuốc có thành phần chính là Rosuvastatin. Đây là thuốc được dùng để điều trị tăng cholesterol máu nguyên phát, rối loạn lipid máu hỗn hợp, điều trị tăng cholesterol máu gia đình kiểu đồng hợp tử.",
                 BrandId = 10,
                 Country = "Romania",
                 DiscountPercent = 0.1f
                },
                new Product
                {
                 Id = 7,
                 Name = "Thuốc Valsartan-MV 80mg USP",
                 UnitPrice = 132.000,
                 PriceSold = 120.000,
                 Quantity = 100,
                 QuantitySold = 0,
                 Description = "Valsartan-MV 80mg được sản xuất bởi Công ty TNHH US Pharma USA, thành phần chính là valsartan, được dùng để điều trị bệnh tăng huyết áp và suy tim ở người lớn và trẻ em trên 6 tuổi. Ngoài ra, thuốc cũng được dùng để tăng cơ hội sống sót kéo dài hơn sau cơn nhồi máu cơ tim.",
                 BrandId = 11,
                 Country = "Việt Nam",
                 DiscountPercent = 0.1f
                },
                new Product
                {
                 Id = 8,
                 Name = "Thuốc Carhurol 10 BRV",
                 UnitPrice = 275.000,
                 PriceSold = 250.000,
                 Quantity = 100,
                 QuantitySold = 0,
                 Description = "Thuốc Carhurol 10 là sản phẩm của Công ty cổ phần BV Pharma. Thuốc có thành phần chính là Rosuvastatin. Đây là thuốc dùng để điều trị tăng cholesterol máu ở người lớn, thanh thiếu niên, trẻ em từ 6 tuổi trở lên và phòng ngừa các biến cố tim mạch.",
                 BrandId = 12,
                 Country = "Việt Nam",
                 DiscountPercent = 0.1f
                },
                new Product
                {
                 Id = 9,
                 Name = "Thuốc Npluvico Nature",
                 UnitPrice = 184.800,
                 PriceSold = 168.000,
                 Quantity = 100,
                 QuantitySold = 0,
                 Description = "Npluvico được sản xuất bởi Công ty Cổ phần Dược Nature Việt Nam. Thuốc có thành phần chính là cao khô lá bạch quả, cao khô rễ đinh lăng.\r\n\r\nNpluvico dùng để điều trị suy tuần hoàn não, rối loạn tuần hoàn ngoại biên, rối loạn thần kinh cảm giác, rối loạn thị giác (bệnh võng mạc), bệnh về tai mũi họng (chóng mặt, ù tai, giảm thính lực), di chứng tai biến mạch máu não và chấn thương sọ não. Phòng ngừa và làm chậm quá trình tiến triển của bệnh Alzheimer ở người lớn tuổi.",
                 BrandId = 13,
                 Country = "Việt Nam",
                 DiscountPercent = 0.1f
                },
                new Product
                {
                 Id = 10,
                 Name = "Thuốc Scanneuron Stella",
                 UnitPrice = 137.500,
                 PriceSold = 125.000,
                 Quantity = 100,
                 QuantitySold = 0,
                 Description = "Scanneuron được sản xuất bởi công ty Stella, thành phần chính là Thiamin nitrat (Vitamin B1), Pyridoxin hydroclorid (vitamin B6), Cyanocobalamin (vitamin B12), được chỉ định để điều trị hỗ trợ các rối loạn về hệ thần kinh như đau dây thần kinh, viêm dây thần kinh ngoại biên, viêm dây thần kinh mắt, viêm dây thần kinh do tiểu đường và do rượu, viêm đa dây thần kinh, dị cảm, đau thần kinh tọa và co giật do tăng tính dễ kích thích của hệ thần kinh trung ương.",
                 BrandId = 13,
                 Country = "Việt Nam",
                 DiscountPercent = 0.1f
                }
                );
            //Image
            modelBuilder.Entity<Image>().HasData(
                new Image { Id = 1, ProductId = 1, ImageLink = "https://cdn.nhathuoclongchau.com.vn/unsafe/636x0/filters:quality(90)/https://cms-prod.s3-sgn09.fptcloud.com/00033777_fluconazole_150mg_stada_1v_4732_624e_large_38eebb47c6.jpg", Thumbnail = true, IsDeleted = false},
                new Image { Id = 2, ProductId = 1, ImageLink = "https://cdn.nhathuoclongchau.com.vn/unsafe/636x0/filters:quality(90)/https://cms-prod.s3-sgn09.fptcloud.com/00033777_fluconazole_150mg_stada_1v_5259_624e_large_672d2b5a9e.jpg", Thumbnail = false, IsDeleted = false},
                new Image { Id = 3, ProductId = 1, ImageLink = "https://cdn.nhathuoclongchau.com.vn/unsafe/636x0/filters:quality(90)/https://cms-prod.s3-sgn09.fptcloud.com/00033777_fluconazole_150mg_stada_1v_7354_624e_large_01a868ca04.jpg", Thumbnail = false, IsDeleted = false},
                new Image { Id = 4, ProductId = 1, ImageLink = "https://cdn.nhathuoclongchau.com.vn/unsafe/636x0/filters:quality(90)/https://cms-prod.s3-sgn09.fptcloud.com/00033777_fluconazole_150mg_stada_1v_7063_624e_large_830492cc36.jpg", Thumbnail = false, IsDeleted = false},
                new Image { Id = 5, ProductId = 1, ImageLink = "https://cdn.nhathuoclongchau.com.vn/unsafe/636x0/filters:quality(90)/https://cms-prod.s3-sgn09.fptcloud.com/00033777_fluconazole_150mg_stada_1v_2072_624e_large_7c79ce80d5.jpg", Thumbnail = false, IsDeleted = false},
                new Image { Id = 6, ProductId = 1, ImageLink = "https://cdn.nhathuoclongchau.com.vn/unsafe/636x0/filters:quality(90)/https://cms-prod.s3-sgn09.fptcloud.com/00033777_fluconazole_150mg_stada_1v_3524_624e_large_68760098c9.jpg", Thumbnail = false, IsDeleted = false},
                new Image { Id = 7, ProductId = 2, ImageLink = "https://cdn.nhathuoclongchau.com.vn/unsafe/636x0/filters:quality(90)/https://cms-prod.s3-sgn09.fptcloud.com/00500234_hoat_huyet_truong_phuc_3x10_3439_6293_large_fce5c74dce.jpg", Thumbnail = true, IsDeleted = false},
                new Image { Id = 8, ProductId = 2, ImageLink = "https://cdn.nhathuoclongchau.com.vn/unsafe/636x0/filters:quality(90)/https://cms-prod.s3-sgn09.fptcloud.com/00500234_hoat_huyet_truong_phuc_3x10_1339_6293_large_2fbeef8a80.jpg", Thumbnail = false, IsDeleted = false},
                new Image { Id = 9, ProductId = 2, ImageLink = "https://cdn.nhathuoclongchau.com.vn/unsafe/636x0/filters:quality(90)/https://cms-prod.s3-sgn09.fptcloud.com/00500234_hoat_huyet_truong_phuc_3x10_9001_6293_large_d466889fe8.jpg", Thumbnail = false, IsDeleted = false},
                new Image { Id = 10, ProductId = 2, ImageLink = "https://cdn.nhathuoclongchau.com.vn/unsafe/636x0/filters:quality(90)/https://cms-prod.s3-sgn09.fptcloud.com/00500234_hoat_huyet_truong_phuc_3x10_5493_6293_large_eaef9efed8.jpg", Thumbnail = false, IsDeleted = false},
                new Image { Id = 11, ProductId = 2, ImageLink = "https://cdn.nhathuoclongchau.com.vn/unsafe/636x0/filters:quality(90)/https://cms-prod.s3-sgn09.fptcloud.com/00500234_hoat_huyet_truong_phuc_3x10_5613_6293_large_b6207da4c9.jpg", Thumbnail = false, IsDeleted = false},
                new Image { Id = 12, ProductId = 2, ImageLink = "https://cdn.nhathuoclongchau.com.vn/unsafe/636x0/filters:quality(90)/https://cms-prod.s3-sgn09.fptcloud.com/00500234_hoat_huyet_truong_phuc_3x10_5302_6293_large_cb9d8bb7d0.jpg", Thumbnail = false, IsDeleted = false},
                new Image { Id = 13, ProductId = 3, ImageLink = "https://cdn.nhathuoclongchau.com.vn/unsafe/636x0/filters:quality(90)/https://cms-prod.s3-sgn09.fptcloud.com/00014376_ginkokup_40_1754_61c9_large_1c441194d7.jpg", Thumbnail = true, IsDeleted = false},
                new Image { Id = 14, ProductId = 3, ImageLink = "https://cdn.nhathuoclongchau.com.vn/unsafe/636x0/filters:quality(90)/https://cms-prod.s3-sgn09.fptcloud.com/00014376_ginkokup_40_4870_61ca_large_d695e0e56c.jpg", Thumbnail = false, IsDeleted = false},
                new Image { Id = 15, ProductId = 3, ImageLink = "https://cdn.nhathuoclongchau.com.vn/unsafe/636x0/filters:quality(90)/https://cms-prod.s3-sgn09.fptcloud.com/00014376_ginkokup_40_7727_61c9_large_0288abb0c6.jpg", Thumbnail = false, IsDeleted = false},
                new Image { Id = 16, ProductId = 3, ImageLink = "https://cdn.nhathuoclongchau.com.vn/unsafe/636x0/filters:quality(90)/https://cms-prod.s3-sgn09.fptcloud.com/00014376_ginkokup_40_3531_61c9_large_239e93283d.jpg", Thumbnail = false, IsDeleted = false},
                new Image { Id = 17, ProductId = 3, ImageLink = "https://cdn.nhathuoclongchau.com.vn/unsafe/636x0/filters:quality(90)/https://cms-prod.s3-sgn09.fptcloud.com/00014376_ginkokup_40_7982_61c9_large_d93fb7b527.jpg", Thumbnail = false, IsDeleted = false},
                new Image { Id = 18, ProductId = 3, ImageLink = "https://cdn.nhathuoclongchau.com.vn/unsafe/636x0/filters:quality(90)/https://cms-prod.s3-sgn09.fptcloud.com/00014376_ginkokup_40_9403_61c9_large_62caccad63.jpg", Thumbnail = false, IsDeleted = false},
                new Image { Id = 19, ProductId = 3, ImageLink = "https://cdn.nhathuoclongchau.com.vn/unsafe/636x0/filters:quality(90)/https://cms-prod.s3-sgn09.fptcloud.com/00014376_ginkokup_40_4751_61c9_large_8104fe3818.jpg", Thumbnail = false, IsDeleted = false},
                new Image { Id = 20, ProductId = 4, ImageLink = "https://cdn.nhathuoclongchau.com.vn/unsafe/636x0/filters:quality(90)/https://cms-prod.s3-sgn09.fptcloud.com/00029275_dacolfort_500mg_danapha_3x10_6954_6062_large_fdad157540.jpg", Thumbnail = true, IsDeleted = false},
                new Image { Id = 21, ProductId = 4, ImageLink = "https://cdn.nhathuoclongchau.com.vn/unsafe/636x0/filters:quality(90)/https://cms-prod.s3-sgn09.fptcloud.com/00029275_dacolfort_500mg_danapha_3x10_9199_6062_large_76a7c96d6f.jpg", Thumbnail = false, IsDeleted = false},
                new Image { Id = 22, ProductId = 4, ImageLink = "https://cdn.nhathuoclongchau.com.vn/unsafe/636x0/filters:quality(90)/https://cms-prod.s3-sgn09.fptcloud.com/00029275_dacolfort_500mg_danapha_3x10_4671_6062_large_a94f37f148.jpg", Thumbnail = false, IsDeleted = false},
                new Image { Id = 23, ProductId = 4, ImageLink = "https://cdn.nhathuoclongchau.com.vn/unsafe/636x0/filters:quality(90)/https://cms-prod.s3-sgn09.fptcloud.com/00029275_dacolfort_500mg_danapha_3x10_9994_6062_large_aaf9f67a9d.jpg", Thumbnail = false, IsDeleted = false},
                new Image { Id = 24, ProductId = 5, ImageLink = "https://cdn.nhathuoclongchau.com.vn/unsafe/636x0/filters:quality(90)/https://cms-prod.s3-sgn09.fptcloud.com/DSC_09967_d0eba34d24.jpg", Thumbnail = true, IsDeleted = false},
                new Image { Id = 25, ProductId = 5, ImageLink = "https://cdn.nhathuoclongchau.com.vn/unsafe/636x0/filters:quality(90)/https://cms-prod.s3-sgn09.fptcloud.com/DSC_09971_b413c0cf14.jpg", Thumbnail = false, IsDeleted = false},
                new Image { Id = 26, ProductId = 5, ImageLink = "https://cdn.nhathuoclongchau.com.vn/unsafe/636x0/filters:quality(90)/https://cms-prod.s3-sgn09.fptcloud.com/DSC_09973_817ea771bb.jpg", Thumbnail = false, IsDeleted = false},
                new Image { Id = 27, ProductId = 6, ImageLink = "https://cdn.nhathuoclongchau.com.vn/unsafe/636x0/filters:quality(90)/https://cms-prod.s3-sgn09.fptcloud.com/DSC_00172_a49dadfd55.jpg", Thumbnail = true, IsDeleted = false},
                new Image { Id = 28, ProductId = 6, ImageLink = "https://cdn.nhathuoclongchau.com.vn/unsafe/636x0/filters:quality(90)/https://cms-prod.s3-sgn09.fptcloud.com/DSC_00175_8f116c3675.jpg", Thumbnail = false, IsDeleted = false},
                new Image { Id = 29, ProductId = 6, ImageLink = "https://cdn.nhathuoclongchau.com.vn/unsafe/636x0/filters:quality(90)/https://cms-prod.s3-sgn09.fptcloud.com/DSC_00178_b91485146e.jpg", Thumbnail = false, IsDeleted = false},
                new Image { Id = 30, ProductId = 6, ImageLink = "https://cdn.nhathuoclongchau.com.vn/unsafe/636x0/filters:quality(90)/https://cms-prod.s3-sgn09.fptcloud.com/DSC_00179_b1dc3be312.jpg", Thumbnail = false, IsDeleted = false},
                new Image { Id = 31, ProductId = 7, ImageLink = "https://cdn.nhathuoclongchau.com.vn/unsafe/636x0/filters:quality(90)/https://cms-prod.s3-sgn09.fptcloud.com/DSC_03394_e628d9caee.jpg", Thumbnail = true, IsDeleted = false},
                new Image { Id = 32, ProductId = 7, ImageLink = "https://cdn.nhathuoclongchau.com.vn/unsafe/636x0/filters:quality(90)/https://cms-prod.s3-sgn09.fptcloud.com/DSC_03398_copy_12c67a69b8.jpg", Thumbnail = false, IsDeleted = false},
                new Image { Id = 33, ProductId = 7, ImageLink = "https://cdn.nhathuoclongchau.com.vn/unsafe/636x0/filters:quality(90)/https://cms-prod.s3-sgn09.fptcloud.com/DSC_03397_842e04f439.jpg", Thumbnail = false, IsDeleted = false},
                new Image { Id = 34, ProductId = 7, ImageLink = "https://cdn.nhathuoclongchau.com.vn/unsafe/636x0/filters:quality(90)/https://cms-prod.s3-sgn09.fptcloud.com/DSC_03400_ec50318d8e.jpg", Thumbnail = false, IsDeleted = false},
                new Image { Id = 35, ProductId = 7, ImageLink = "https://cdn.nhathuoclongchau.com.vn/unsafe/636x0/filters:quality(90)/https://cms-prod.s3-sgn09.fptcloud.com/DSC_03401_b375b86c28.jpg", Thumbnail = false, IsDeleted = false},
                new Image { Id = 36, ProductId = 8, ImageLink = "https://cdn.nhathuoclongchau.com.vn/unsafe/636x0/filters:quality(90)/https://cms-prod.s3-sgn09.fptcloud.com/DSC_03512_efbea39e45.jpg", Thumbnail = true, IsDeleted = false},
                new Image { Id = 37, ProductId = 8, ImageLink = "https://cdn.nhathuoclongchau.com.vn/unsafe/636x0/filters:quality(90)/https://cms-prod.s3-sgn09.fptcloud.com/DSC_03515_38d3012027.jpg", Thumbnail = false, IsDeleted = false},
                new Image { Id = 38, ProductId = 8, ImageLink = "https://cdn.nhathuoclongchau.com.vn/unsafe/636x0/filters:quality(90)/https://cms-prod.s3-sgn09.fptcloud.com/DSC_03520_06e66bad9f.jpg", Thumbnail = false, IsDeleted = false},
                new Image { Id = 39, ProductId = 8, ImageLink = "https://cdn.nhathuoclongchau.com.vn/unsafe/636x0/filters:quality(90)/https://cms-prod.s3-sgn09.fptcloud.com/DSC_03521_7efa50bb0f.jpg", Thumbnail = false, IsDeleted = false},
                new Image { Id = 40, ProductId = 9, ImageLink = "https://cdn.nhathuoclongchau.com.vn/unsafe/636x0/filters:quality(90)/https://cms-prod.s3-sgn09.fptcloud.com/DSC_00146_7d022b2ddd.jpg", Thumbnail = true, IsDeleted = false},
                new Image { Id = 41, ProductId = 9, ImageLink = "https://cdn.nhathuoclongchau.com.vn/unsafe/636x0/filters:quality(90)/https://cms-prod.s3-sgn09.fptcloud.com/DSC_00152_9dad73d9c3.jpg", Thumbnail = false, IsDeleted = false},
                new Image { Id = 42, ProductId = 9, ImageLink = "https://cdn.nhathuoclongchau.com.vn/unsafe/636x0/filters:quality(90)/https://cms-prod.s3-sgn09.fptcloud.com/DSC_00153_bad1324204.jpg", Thumbnail = false, IsDeleted = false},
                new Image { Id = 43, ProductId = 9, ImageLink = "https://cdn.nhathuoclongchau.com.vn/unsafe/636x0/filters:quality(90)/https://cms-prod.s3-sgn09.fptcloud.com/DSC_00154_baf22f1c94.jpg", Thumbnail = false, IsDeleted = false},
                new Image { Id = 44, ProductId = 10, ImageLink = "https://cdn.nhathuoclongchau.com.vn/unsafe/636x0/filters:quality(90)/https://cms-prod.s3-sgn09.fptcloud.com/00006610_scanneuron_forte_4082_61df_large_203eef608c.jpg", Thumbnail = true, IsDeleted = false},
                new Image { Id = 45, ProductId = 10, ImageLink = "https://cdn.nhathuoclongchau.com.vn/unsafe/636x0/filters:quality(90)/https://cms-prod.s3-sgn09.fptcloud.com/00006610_scanneuron_forte_7972_61df_large_bc5e17f862.jpg", Thumbnail = false, IsDeleted = false},
                new Image { Id = 46, ProductId = 10, ImageLink = "https://cdn.nhathuoclongchau.com.vn/unsafe/636x0/filters:quality(90)/https://cms-prod.s3-sgn09.fptcloud.com/00006610_scanneuron_forte_5617_61df_large_7218352645.jpg", Thumbnail = false, IsDeleted = false}
                );
            //ProductMatirel
            modelBuilder.Entity<ProductMaterial>().HasData(
                new ProductMaterial { Id = 1, Detail = "Thuốc kháng nấm", ProductId = 1, MaterialId = 1, IsDeleted = false},
                new ProductMaterial { Id = 2, Detail = "Viên nang cứng", ProductId = 1, MaterialId = 2, IsDeleted = false},
                new ProductMaterial { Id = 3, Detail = "Hộp 1 Vỉ x 1 Viên", ProductId = 1, MaterialId = 3, IsDeleted = false},
                new ProductMaterial { Id = 4, Detail = "Fluconazol", ProductId = 1, MaterialId = 4, IsDeleted = false},
                new ProductMaterial { Id = 5, Detail = "VD-35475-21", ProductId = 1, MaterialId = 5, IsDeleted = false},
                new ProductMaterial { Id = 6, Detail = "Thuốc tăng cường tuần hoàn não", ProductId = 2, MaterialId = 6, IsDeleted = false},
                new ProductMaterial { Id = 7, Detail = "Viên nén bao phim", ProductId = 2, MaterialId = 7, IsDeleted = false},
                new ProductMaterial { Id = 8, Detail = "Hộp 3 Vỉ x 10 Viên", ProductId = 2, MaterialId = 8, IsDeleted = false},
                new ProductMaterial { Id = 9, Detail = "Thục địa, Ích mẫu, Ngưu tất (Rễ), Đương quy, Xích thược, Xuyên khung", ProductId = 2, MaterialId = 9, IsDeleted = false},
                new ProductMaterial { Id = 10, Detail = "VD-30094-18", ProductId = 2, MaterialId = 10, IsDeleted = false},
                new ProductMaterial { Id = 11, Detail = "Thuốc tăng cường tuần hoàn não", ProductId = 3, MaterialId = 6, IsDeleted = false},
                new ProductMaterial { Id = 12, Detail = "Viên nang mềm", ProductId = 3, MaterialId = 7, IsDeleted = false},
                new ProductMaterial { Id = 13, Detail = "Hộp 6 Vỉ x 10 Viên", ProductId = 3, MaterialId = 8, IsDeleted = false},
                new ProductMaterial { Id = 14, Detail = "Ginkgo biloba", ProductId = 3, MaterialId = 9, IsDeleted = false},
                new ProductMaterial { Id = 15, Detail = "VD-27294-17", ProductId = 3, MaterialId = 10, IsDeleted = false},
                new ProductMaterial { Id = 16, Detail = "Thuốc trị trĩ, suy giãn tĩnh mạch", ProductId = 4, MaterialId = 6, IsDeleted = false},
                new ProductMaterial { Id = 17, Detail = "Viên nén bao phim", ProductId = 4, MaterialId = 7, IsDeleted = false},
                new ProductMaterial { Id = 18, Detail = "Hộp 3 Vỉ x 10 Viên", ProductId = 4, MaterialId = 8, IsDeleted = false},
                new ProductMaterial { Id = 19, Detail = "Diosmin, Hesperidin", ProductId = 4, MaterialId = 9, IsDeleted = false},
                new ProductMaterial { Id = 20, Detail = "VD-30231-18", ProductId = 4, MaterialId = 10, IsDeleted = false},
                new ProductMaterial { Id = 21, Detail = "Thuốc trị trĩ, suy giãn tĩnh mạch", ProductId = 5, MaterialId = 6, IsDeleted = false},
                new ProductMaterial { Id = 22, Detail = "Viên nén bao phim", ProductId = 5, MaterialId = 7, IsDeleted = false},
                new ProductMaterial { Id = 23, Detail = "Hộp 10 Vỉ x 10 Viên", ProductId = 5, MaterialId = 8, IsDeleted = false},
                new ProductMaterial { Id = 24, Detail = "Diosmin, Hesperidin", ProductId = 5, MaterialId = 9, IsDeleted = false},
                new ProductMaterial { Id = 25, Detail = "VD-30810-18", ProductId = 5, MaterialId = 10, IsDeleted = false},
                new ProductMaterial { Id = 26, Detail = "Thuốc trị mỡ máu", ProductId = 6, MaterialId = 6, IsDeleted = false},
                new ProductMaterial { Id = 27, Detail = "Viên nén bao phim", ProductId = 6, MaterialId = 7, IsDeleted = false},
                new ProductMaterial { Id = 28, Detail = "Hộp 3 Vỉ x 10 Viên", ProductId = 6, MaterialId = 8, IsDeleted = false},
                new ProductMaterial { Id = 29, Detail = "Rosuvastatin", ProductId = 6, MaterialId = 9, IsDeleted = false},
                new ProductMaterial { Id = 30, Detail = "VN-22675-20", ProductId = 6, MaterialId = 10, IsDeleted = false},
                new ProductMaterial { Id = 31, Detail = "Thuốc tim mạch huyết áp", ProductId = 7, MaterialId = 6, IsDeleted = false},
                new ProductMaterial { Id = 32, Detail = "Viên nén bao phim", ProductId = 7, MaterialId = 7, IsDeleted = false},
                new ProductMaterial { Id = 33, Detail = "Hộp 3 Vỉ x 10 Viên", ProductId = 7, MaterialId = 8, IsDeleted = false},
                new ProductMaterial { Id = 34, Detail = "Valsartan", ProductId = 7, MaterialId = 9, IsDeleted = false},
                new ProductMaterial { Id = 35, Detail = "VD-32469-19", ProductId = 7, MaterialId = 10, IsDeleted = false},
                new ProductMaterial { Id = 36, Detail = "Thuốc trị mỡ máu", ProductId = 8, MaterialId = 6, IsDeleted = false},
                new ProductMaterial { Id = 37, Detail = "Viên nén bao phim", ProductId = 8, MaterialId = 7, IsDeleted = false},
                new ProductMaterial { Id = 38, Detail = "Hộp 3 Vỉ x 10 Viên", ProductId = 8, MaterialId = 8, IsDeleted = false},
                new ProductMaterial { Id = 39, Detail = "Rosuvastatin", ProductId = 8, MaterialId = 9, IsDeleted = false},
                new ProductMaterial { Id = 40, Detail = "VD-31018-18", ProductId = 8, MaterialId = 10, IsDeleted = false},
                new ProductMaterial { Id = 41, Detail = "Thuốc thần kinh", ProductId = 9, MaterialId = 11, IsDeleted = false},
                new ProductMaterial { Id = 42, Detail = "Viên nang mềm", ProductId = 9, MaterialId = 12, IsDeleted = false},
                new ProductMaterial { Id = 43, Detail = "Hộp 6 Vỉ x 10 Viên", ProductId = 9, MaterialId = 13, IsDeleted = false},
                new ProductMaterial { Id = 44, Detail = "Bạch quả, Đinh lăng", ProductId = 9, MaterialId = 14, IsDeleted = false},
                new ProductMaterial { Id = 45, Detail = "VD-21622-14", ProductId = 9, MaterialId = 15, IsDeleted = false},
                new ProductMaterial { Id = 46, Detail = "Thuốc thần kinh", ProductId = 10, MaterialId = 11, IsDeleted = false},
                new ProductMaterial { Id = 47, Detail = "Viên nén bao phim", ProductId = 10, MaterialId = 12, IsDeleted = false},
                new ProductMaterial { Id = 48, Detail = "Hộp 10 vỉ x 10 viên", ProductId = 10, MaterialId = 13, IsDeleted = false},
                new ProductMaterial { Id = 49, Detail = "Vitamin B1, Vitamin B6, Vitamin B12", ProductId = 10, MaterialId = 14, IsDeleted = false},
                new ProductMaterial { Id = 50, Detail = "VD-22677-15", ProductId = 10, MaterialId = 15, IsDeleted = false}
                );
            #endregion
        }


    }
}
