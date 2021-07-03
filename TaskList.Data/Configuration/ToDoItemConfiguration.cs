using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TaskList.Core.Models;

namespace TaskList.Data.Configuration
{
    public class ToDoItemConfiguration : IEntityTypeConfiguration<ToDoItem>
    {
        public void Configure(EntityTypeBuilder<ToDoItem> builder)
        {
            builder
                .HasKey(t => t.ToDoItemId);

            builder
                .Property(t => t.ToDoItemId)
                .UseIdentityColumn();

            builder
                .Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(300);

            builder
                .Property(t => t.IsCompleted)
                .IsRequired();

            builder
                .Property(t => t.IsFromInbox)
                .IsRequired();

            builder
                .HasOne(t => t.Project)
                .WithMany(p => p.ToDoItems)
                .HasForeignKey(t => t.ProjectId);

            builder
                .HasOne(t => t.User)
                .WithMany(u => u.ToDoItems)
                .HasForeignKey(t => t.UserId);

            builder
                .ToTable("ToDoItems");
        }
    }
}
