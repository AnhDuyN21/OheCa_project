using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructures.FluentAPIs
{
    public class DiscountConfiguration : IEntityTypeConfiguration<Discount>
    {
        public void Configure(EntityTypeBuilder<Discount> builder)
        {
            builder.HasKey(d => d.Id);

            builder.Property(d => d.Id).ValueGeneratedOnAdd();

            builder.HasOne(d => d.Product)
                .WithMany(d => d.Discounts)
                .HasForeignKey(d => d.ProductId);

        }
    }
}
