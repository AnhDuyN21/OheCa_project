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
    public class FeedbackConfiguration : IEntityTypeConfiguration<Feedback>
    {
        public void Configure(EntityTypeBuilder<Feedback> builder)
        {
            builder.HasKey(f => f.Id);

            builder.Property(f => f.Id).ValueGeneratedOnAdd();

            builder.HasOne(f => f.Product)
                .WithMany(f => f.Feedbacks)
                .HasForeignKey(f => f.ProductId);

            builder.HasOne(f => f.User)
                .WithMany(f => f.Feedbacks)
                .HasForeignKey(f => f.UserId);
        }
    }
}
