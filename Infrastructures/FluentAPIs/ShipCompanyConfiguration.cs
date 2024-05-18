using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Infrastructures.FluentAPIs
{
    public class ShipCompanyConfiguration : IEntityTypeConfiguration<ShipCompany>
    {
        public void Configure(EntityTypeBuilder<ShipCompany> builder)
        {
            builder.HasKey(s => s.Id);

            builder.Property(s => s.Id).ValueGeneratedOnAdd();

            builder.HasMany(s => s.Shippers)
                .WithOne(s => s.ShipCompany);
            
        }
    }
}
