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
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Id).ValueGeneratedOnAdd();

            builder.HasMany(u => u.AddressUsers)
                .WithOne(u => u.User);

            builder.HasMany(u => u.Feedbacks)
                .WithOne(u => u.User);

            builder.HasMany(u => u.Orders)
                .WithOne(u => u.User);

            builder.HasMany(u => u.Posts)
                .WithOne(u => u.User);

            builder.HasMany(u => u.Comments)
                .WithOne(u => u.User);

            builder.HasOne(u => u.Role)
                .WithMany(u => u.Users)
                .HasForeignKey(u => u.RoleId);
        }
    }
}
