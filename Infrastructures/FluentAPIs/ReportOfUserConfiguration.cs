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
    public class ReportOfUserConfiguration : IEntityTypeConfiguration<ReportOfUser>
    {
        public void Configure(EntityTypeBuilder<ReportOfUser> builder)
        {
            builder.HasKey(r => r.Id);

            builder.Property(r => r.Id).ValueGeneratedOnAdd();

            builder.HasOne(r => r.Comment)
                .WithMany(r => r.ReportOfUsers)
                .HasForeignKey(r => r.CommentId);

            builder.HasOne(r => r.ReportType)
                .WithMany(r => r.ReportOfUsers)
                .HasForeignKey(r => r.ReportTypeId);

        }
    }
}
