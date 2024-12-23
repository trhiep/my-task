﻿using Microsoft.EntityFrameworkCore;
using MyTaskAPI.Models;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace MyTaskAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<MyTaskAPI.Models.Task> Tasks { get; set; }
        public DbSet<Step> Steps { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var conf = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
                optionsBuilder.UseSqlServer(conf.GetConnectionString("DefaultConnection"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // User Table
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UserId);
                entity.Property(e => e.UserId).UseIdentityColumn(1, 1);
                entity.Property(e => e.Email).IsRequired().HasMaxLength(100);
                entity.Property(e => e.FullName).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Password).IsRequired();
                entity.Property(e => e.Role).IsRequired().HasMaxLength(10);
            });

            // Task Table
            modelBuilder.Entity<MyTaskAPI.Models.Task>(entity =>
            {
                entity.HasKey(e => e.TaskId);
                entity.Property(e => e.TaskId).UseIdentityColumn();
                entity.Property(e => e.TaskName).IsRequired().HasMaxLength(255);
                entity.Property(e => e.Description).HasMaxLength(500);
                entity.Property(e => e.IsImportant).IsRequired();
                entity.Property(e => e.CreatedDate).IsRequired();
                entity.Property(e => e.IsCompleted).IsRequired();

                // Relationship
                entity.HasOne(e => e.User)
                    .WithMany(u => u.Tasks)
                    .HasForeignKey(e => e.UserId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // Step Table
            modelBuilder.Entity<Step>(entity =>
            {
                entity.HasKey(e => e.StepId);
                entity.Property(e => e.StepId).UseIdentityColumn();
                entity.Property(e => e.StepNumber).IsRequired();
                entity.Property(e => e.StepName).IsRequired().HasMaxLength(1000);
                entity.Property(e => e.IsCompleted).IsRequired();

                // Relationship
                entity.HasOne(e => e.Task)
                    .WithMany(t => t.Steps)
                    .HasForeignKey(e => e.TaskId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
