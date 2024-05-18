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
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(o => o.Id);

            builder.Property(o => o.Id).ValueGeneratedOnAdd();

            builder.HasOne(o => o.AddressToShip)
                .WithMany(o => o.Orders)
                .HasForeignKey(o => o.AddressToShipId);

            builder.HasMany(o => o.OrderDetails)
                .WithOne(o => o.Order);

            builder.HasOne(o => o.Payment)
                .WithMany(o => o.Orders)
                .HasForeignKey(o => o.PaymentId);

            builder.HasOne(o => o.Shipper)
                .WithMany(o => o.Orders)
                .HasForeignKey(o => o.ShipperId);

            builder.HasOne(o => o.User)
                .WithMany(o => o.Orders)
                .HasForeignKey(o => o.UserId);

            builder.HasMany(o => o.VoucherUsages)
                .WithOne(o => o.Order);
                
        }
    }
}
