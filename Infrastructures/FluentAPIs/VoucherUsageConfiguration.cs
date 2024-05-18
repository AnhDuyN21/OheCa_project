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
    public class VoucherUsageConfiguration : IEntityTypeConfiguration<VoucherUsage>
    {
        public void Configure(EntityTypeBuilder<VoucherUsage> builder)
        {
            builder.HasKey(v => v.Id);

            builder.Property(v => v.Id).ValueGeneratedOnAdd();

            builder.HasOne(v => v.Order)
                .WithMany(v => v.VoucherUsages)
                .HasForeignKey(v => v.OrderId);

            builder.HasOne(v => v.Voucher)
                .WithMany(v => v.VoucherUsages)
                .HasForeignKey(v => v.VoucherId);
        }
    }
}
