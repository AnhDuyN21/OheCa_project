using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Infrastructures.FluentAPIs
{
    public class AddressToShipConfiguration : IEntityTypeConfiguration<AddressToShip>
    {
        public void Configure(EntityTypeBuilder<AddressToShip> builder)
        {
            builder.HasKey(ats => ats.Id);

            builder.Property(ats => ats.Id).ValueGeneratedOnAdd();

            builder.HasMany(ats => ats.Orders)
                .WithOne(ats => ats.AddressToShip);

            builder.HasMany(ats => ats.AddressUsers)
                .WithOne(ats => ats.AddressToShip);
        }
    }
}
