using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;


namespace Infrastructures.FluentAPIs
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).ValueGeneratedOnAdd();

            builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(100);


            builder.HasMany(p => p.Discounts)
                .WithOne(p => p.Product);

            builder.HasMany(p => p.Images)
                .WithOne(p => p.Product);

            builder.HasOne(p => p.Brand)
                .WithMany(p => p.Products)
                .HasForeignKey(p => p.BrandId);

            builder.HasMany(p => p.ProductMaterials)
                .WithOne(p => p.Product);

            builder.HasMany(p => p.OrderDetails)
                .WithOne(p => p.Product);

            builder.HasMany(p => p.Feedbacks)
                .WithOne(p => p.Product);
                

        }
     }
}
