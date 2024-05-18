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
    public class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.HasKey(od => od.Id);

            builder.Property(od => od.Id).ValueGeneratedOnAdd();

            builder.HasOne(od => od.Order)
                .WithMany(od => od.OrderDetails)
                .HasForeignKey(od => od.OrderId);

            builder.HasOne(od => od.Product)
                .WithMany(od => od.OrderDetails)
                .HasForeignKey(od => od.ProductId);
        }
    }
}
