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
            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 1, Name = "Customer", Description = "Customer", IsDeleted = false },
                new Role { Id = 2, Name = "Admin", Description = "Admin", IsDeleted = false }
                );
        }


    }
}
