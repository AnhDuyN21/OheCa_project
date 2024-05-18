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
    public class ParentCategoryConfiguration : IEntityTypeConfiguration<ParentCategory>
    {
        public void Configure(EntityTypeBuilder<ParentCategory> builder)
        {
            builder.HasKey(pc => pc.Id);

            builder.Property(pc => pc.Id).ValueGeneratedOnAdd();

            builder.HasMany(pc => pc.ChildCategories)
                .WithOne(pc => pc.ParentCategory);
        }
    }
}
