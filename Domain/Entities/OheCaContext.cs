using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Domain.Entities;

public partial class OheCaContext : DbContext
{
    public OheCaContext()
    {
    }

    public OheCaContext(DbContextOptions<OheCaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AddressToShip> AddressToShips { get; set; }

    public virtual DbSet<AddressUser> AddressUsers { get; set; }

    public virtual DbSet<Brand> Brands { get; set; }

    public virtual DbSet<ChildCategory> ChildCategories { get; set; }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<Discount> Discounts { get; set; }

    public virtual DbSet<Feedback> Feedbacks { get; set; }

    public virtual DbSet<Image> Images { get; set; }

    public virtual DbSet<Material> Materials { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public virtual DbSet<ParentCategory> ParentCategories { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Post> Posts { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductMaterial> ProductMaterials { get; set; }

    public virtual DbSet<ReportOfUser> ReportOfUsers { get; set; }

    public virtual DbSet<ReportType> ReportTypes { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<ShipCompany> ShipCompanies { get; set; }

    public virtual DbSet<Shipper> Shippers { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Voucher> Vouchers { get; set; }

    public virtual DbSet<VoucherUsage> VoucherUsages { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(GetConnectionString());

    private string GetConnectionString()
    {
        IConfiguration config = new ConfigurationBuilder()
             .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", true, true)
                    .Build();
        var strConn = config.GetConnectionString("DBConnect");

        return strConn;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AddressToShip>(entity =>
        {
            entity.ToTable("AddressToShip");

            entity.Property(e => e.Id).HasColumnName("ID");
        });

        modelBuilder.Entity<AddressUser>(entity =>
        {
            entity.ToTable("AddressUser");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AddressToShipId).HasColumnName("AddressToShipID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.AddressToShip).WithMany(p => p.AddressUsers)
                .HasForeignKey(d => d.AddressToShipId)
                .HasConstraintName("FK_AddressUser_AddressToShip");

            entity.HasOne(d => d.User).WithMany(p => p.AddressUsers)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_AddressUser_User");
        });

        modelBuilder.Entity<Brand>(entity =>
        {
            entity.ToTable("Brand");

            entity.Property(e => e.Id).HasColumnName("ID");
        });

        modelBuilder.Entity<ChildCategory>(entity =>
        {
            entity.ToTable("ChildCategory");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ParentCategoryId).HasColumnName("ParentCategoryID");

            entity.HasOne(d => d.ParentCategory).WithMany(p => p.ChildCategories)
                .HasForeignKey(d => d.ParentCategoryId)
                .HasConstraintName("FK_ChildCategory_ParentCategory");
        });

        modelBuilder.Entity<Comment>(entity =>
        {
            entity.ToTable("Comment");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CommentDate).HasColumnType("datetime");
            entity.Property(e => e.PostId).HasColumnName("PostID");

            entity.HasOne(d => d.Post).WithMany(p => p.Comments)
                .HasForeignKey(d => d.PostId)
                .HasConstraintName("FK_Comment_Post");
        });

        modelBuilder.Entity<Discount>(entity =>
        {
            entity.ToTable("Discount");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Discount1).HasColumnName("Discount");
            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.StartDate).HasColumnType("datetime");

            entity.HasOne(d => d.Product).WithMany(p => p.Discounts)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_Discount_Product");
        });

        modelBuilder.Entity<Feedback>(entity =>
        {
            entity.ToTable("Feedback");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Product).WithMany(p => p.Feedbacks)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_Feedback_Product");

            entity.HasOne(d => d.User).WithMany(p => p.Feedbacks)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_Feedback_User");
        });

        modelBuilder.Entity<Image>(entity =>
        {
            entity.ToTable("Image");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.ImageCode)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.UpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Product).WithMany(p => p.Images)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_Image_Product");
        });

        modelBuilder.Entity<Material>(entity =>
        {
            entity.ToTable("Material");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ChildCategoryId).HasColumnName("ChildCategoryID");

            entity.HasOne(d => d.ChildCategory).WithMany(p => p.Materials)
                .HasForeignKey(d => d.ChildCategoryId)
                .HasConstraintName("FK_Material_ChildCategory");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.ToTable("Order");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AddressToShipId).HasColumnName("AddressToShipID");
            entity.Property(e => e.OrderDate).HasColumnType("datetime");
            entity.Property(e => e.PaymentId).HasColumnName("PaymentID");
            entity.Property(e => e.ReceiveDate).HasColumnType("datetime");
            entity.Property(e => e.ShipDate).HasColumnType("datetime");
            entity.Property(e => e.ShipperId).HasColumnName("ShipperID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.AddressToShip).WithMany(p => p.Orders)
                .HasForeignKey(d => d.AddressToShipId)
                .HasConstraintName("FK_Order_AddressToShip");

            entity.HasOne(d => d.Payment).WithMany(p => p.Orders)
                .HasForeignKey(d => d.PaymentId)
                .HasConstraintName("FK_Order_Payment");

            entity.HasOne(d => d.Shipper).WithMany(p => p.Orders)
                .HasForeignKey(d => d.ShipperId)
                .HasConstraintName("FK_Order_Shipper");

            entity.HasOne(d => d.User).WithMany(p => p.Orders)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_Order_User");
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.ToTable("OrderDetail");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK_OrderDetail_Order");

            entity.HasOne(d => d.Product).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_OrderDetail_Product");
        });

        modelBuilder.Entity<ParentCategory>(entity =>
        {
            entity.ToTable("ParentCategory");

            entity.Property(e => e.Id).HasColumnName("ID");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.ToTable("Payment");

            entity.Property(e => e.Id).HasColumnName("ID");
        });

        modelBuilder.Entity<Post>(entity =>
        {
            entity.ToTable("Post");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreateDate).HasColumnType("datetime");

            entity.HasOne(d => d.CreateByNavigation).WithMany(p => p.Posts)
                .HasForeignKey(d => d.CreateBy)
                .HasConstraintName("FK_Post_User");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.ToTable("Product");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.BrandId).HasColumnName("BrandID");
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.UpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Brand).WithMany(p => p.Products)
                .HasForeignKey(d => d.BrandId)
                .HasConstraintName("FK_Product_Brand");
        });

        modelBuilder.Entity<ProductMaterial>(entity =>
        {
            entity.ToTable("ProductMaterial");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.MaterialId).HasColumnName("MaterialID");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");

            entity.HasOne(d => d.Material).WithMany(p => p.ProductMaterials)
                .HasForeignKey(d => d.MaterialId)
                .HasConstraintName("FK_ProductMaterial_Material");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductMaterials)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_ProductMaterial_Product");
        });

        modelBuilder.Entity<ReportOfUser>(entity =>
        {
            entity.ToTable("ReportOfUser");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CommentId).HasColumnName("CommentID");
            entity.Property(e => e.ReportTypeId).HasColumnName("ReportTypeID");

            entity.HasOne(d => d.Comment).WithMany(p => p.ReportOfUsers)
                .HasForeignKey(d => d.CommentId)
                .HasConstraintName("FK_ReportOfUser_Comment");

            entity.HasOne(d => d.ReportType).WithMany(p => p.ReportOfUsers)
                .HasForeignKey(d => d.ReportTypeId)
                .HasConstraintName("FK_ReportOfUser_ReportType");
        });

        modelBuilder.Entity<ReportType>(entity =>
        {
            entity.ToTable("ReportType");

            entity.Property(e => e.Id).HasColumnName("ID");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.ToTable("Role");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Description).IsRequired();
            entity.Property(e => e.Name).IsRequired();
        });

        modelBuilder.Entity<ShipCompany>(entity =>
        {
            entity.ToTable("ShipCompany");

            entity.Property(e => e.Id).HasColumnName("ID");
        });

        modelBuilder.Entity<Shipper>(entity =>
        {
            entity.ToTable("Shipper");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ShipCompanyId).HasColumnName("ShipCompanyID");

            entity.HasOne(d => d.ShipCompany).WithMany(p => p.Shippers)
                .HasForeignKey(d => d.ShipCompanyId)
                .HasConstraintName("FK_Shipper_ShipCompany");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__User__3213E83F569DD468");

            entity.ToTable("User");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Avatar)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.DeletedDate).HasColumnType("datetime");
            entity.Property(e => e.FirstName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Phone).HasMaxLength(50);
            entity.Property(e => e.RoleId).HasColumnName("RoleID");
            entity.Property(e => e.UpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK_User_Role");
        });

        modelBuilder.Entity<Voucher>(entity =>
        {
            entity.ToTable("Voucher");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreateTime).HasColumnType("datetime");
            entity.Property(e => e.EndTime).HasColumnType("datetime");
            entity.Property(e => e.StartTime).HasColumnType("datetime");
            entity.Property(e => e.UpdateTime).HasColumnType("datetime");
        });

        modelBuilder.Entity<VoucherUsage>(entity =>
        {
            entity.ToTable("VoucherUsage");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.TimeUsage).HasColumnType("datetime");
            entity.Property(e => e.VoucherId).HasColumnName("VoucherID");

            entity.HasOne(d => d.Order).WithMany(p => p.VoucherUsages)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK_VoucherUsage_Order");

            entity.HasOne(d => d.Voucher).WithMany(p => p.VoucherUsages)
                .HasForeignKey(d => d.VoucherId)
                .HasConstraintName("FK_VoucherUsage_Voucher");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
