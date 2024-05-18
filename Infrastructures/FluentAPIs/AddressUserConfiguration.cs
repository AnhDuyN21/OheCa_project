using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructures.FluentAPIs
{
    public class AddressUserConfiguration : IEntityTypeConfiguration<AddressUser>
    {
        public void Configure(EntityTypeBuilder<AddressUser> builder)
        {
            builder.HasKey(au => au.Id);

            builder.Property(au => au.Id).ValueGeneratedOnAdd();

            builder.HasOne(au => au.User)
                .WithMany(au => au.AddressUsers)
                .HasForeignKey(au => au.UserId);

            builder.HasOne(au => au.AddressToShip)
                .WithMany(au => au.AddressUsers)
                .HasForeignKey(au => au.AddressToShipId);

        }
    }
}
