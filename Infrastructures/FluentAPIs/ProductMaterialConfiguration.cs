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
    public class ProductMaterialConfiguration : IEntityTypeConfiguration<ProductMaterial>
    {
        public void Configure(EntityTypeBuilder<ProductMaterial> builder)
        {
            builder.HasKey(pm => pm.Id);

            builder.Property(pm => pm.Id).ValueGeneratedOnAdd();

            builder.HasOne(pm => pm.Material)
                .WithMany(pm => pm.ProductMaterials)
                .HasForeignKey(pm => pm.MaterialId);

            builder.HasOne(pm => pm.Product)
                .WithMany(pm => pm.ProductMaterials)
                .HasForeignKey(pm => pm.ProductId);
        }
    }
}
