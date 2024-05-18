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
    public class ChildCategoryConfiguration : IEntityTypeConfiguration<ChildCategory>
    {
        public void Configure(EntityTypeBuilder<ChildCategory> builder)
        {
            builder.HasKey(cc => cc.Id);

            builder.Property(cc => cc.Id).ValueGeneratedOnAdd();

            builder.HasMany(cc => cc.Materials)
                .WithOne(cc => cc.ChildCategory);

            builder.HasOne(cc => cc.ParentCategory)
                .WithMany(cc => cc.ChildCategories)
                .HasForeignKey(x => x.ParentCategoryId);
                
        }
    }
}
