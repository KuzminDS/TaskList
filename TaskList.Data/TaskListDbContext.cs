using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TaskList.Data.Configuration;
using TaskList.Core.Models;

namespace TaskList.Data
{
    public class TaskListDbContext : DbContext
    {
        public DbSet<ToDoItem> ToDoItems { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<User> Users { get; set; }

        public TaskListDbContext(DbContextOptions<TaskListDbContext> options) 
            : base(options) 
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .ApplyConfiguration(new ToDoItemConfiguration());

            modelBuilder
                .ApplyConfiguration(new ProjectConfiguration());

            modelBuilder
                .ApplyConfiguration(new UserConfiguration());
        }
    }
}
