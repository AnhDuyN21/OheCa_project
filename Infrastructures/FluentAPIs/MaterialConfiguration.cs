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
    public class MaterialConfiguration : IEntityTypeConfiguration<Material>
    {
        public void Configure(EntityTypeBuilder<Material> builder)
        {
            builder.HasKey(m => m.Id);

            builder.Property(m => m.Id).ValueGeneratedOnAdd();

            builder.HasOne(m => m.ChildCategory)
                .WithMany(m => m.Materials)
                .HasForeignKey(m => m.ChildCategoryId);

            builder.HasMany(m => m.ProductMaterials)
                .WithOne(m => m.Material);
        }
    }
}
