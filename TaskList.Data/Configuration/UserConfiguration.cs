using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TaskList.Core.Models;

namespace TaskList.Data.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .HasKey(p => p.UserId);

            builder
                .Property(p => p.UserId)
                .UseIdentityColumn();

            builder
                .Property(p => p.LastName)
                .IsRequired()
                .HasMaxLength(300);

            builder
                .Property(p => p.FirstName)
                .IsRequired()
                .HasMaxLength(300);

            builder
                .Property(p => p.Login)
                .IsRequired()
                .HasMaxLength(300);

            builder
                .Property(p => p.Password)
                .IsRequired()
                .HasMaxLength(300);

            builder
                .ToTable("Users");
        }
    }
}
