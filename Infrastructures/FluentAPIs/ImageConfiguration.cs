using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;



namespace Infrastructures.FluentAPIs
{
    public class ImageConfiguration : IEntityTypeConfiguration<Image>
    {

        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.HasKey(i => i.Id);

            builder.Property(ats => ats.Id).ValueGeneratedOnAdd();

            builder.HasOne(i => i.Product)
                .WithMany(i => i.Images)
                .HasForeignKey(i => i.ProductId);
        }
    }
}
