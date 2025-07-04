// <copyright file="DataContext.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Tekus.Infrastructure
{
    using Microsoft.EntityFrameworkCore;
    using Tekus.Entities;

    /// <summary>
    /// DataContext class for managing the database context.
    /// </summary>
    /// <param name="options">options.</param>
    public class DataContext(DbContextOptions<DataContext> options)
        : DbContext(options)
    {
        /// <summary>
        /// Gets or sets dbSet for Suppliers.
        /// </summary>
        public DbSet<Supplier> Suppliers { get; set; }

        /// <summary>
        /// Gets or sets dbSet for Services.
        /// </summary>
        public DbSet<Service> Services { get; set; }

        /// <summary>
        /// Gets or sets dbSet for SupplierServices.
        /// </summary>
        public DbSet<SupplierService> SupplierServices { get; set; }

        /// <summary>
        /// Configures the model for the database context.
        /// </summary>
        /// <param name="modelBuilder"> modelbuilder.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.Property(e => e.SupplierID).ValueGeneratedOnAdd();
                entity.Property(e => e.Identification).HasMaxLength(16).IsRequired();
                entity.Property(e => e.Name).HasMaxLength(256).IsRequired();
                entity.Property(e => e.EmailAddress).HasMaxLength(256).IsRequired();

                entity.HasKey(e => e.SupplierID);
                entity.HasIndex(e => e.Identification).IsUnique();
                entity.HasIndex(e => e.Name);
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.Property(e => e.ServiceID).ValueGeneratedOnAdd();
                entity.Property(e => e.Name).HasMaxLength(256).IsRequired();
                entity.Property(e => e.Price).HasPrecision(12, 2).IsRequired();

                entity.HasKey(e => e.ServiceID);
                entity.HasIndex(e => e.Name);
            });

            modelBuilder.Entity<SupplierService>(entity =>
            {
                // Indicate that SupplierID is auto-increment (identity)
                entity.HasKey(e => new { e.SupplierID, e.ServiceID });
                entity.HasOne(m => m.Supplier).WithMany(m => m.SupplierServices).HasForeignKey(m => m.SupplierID);
                entity.HasOne(m => m.Service).WithMany(m => m.SupplierServices).HasForeignKey(m => m.ServiceID);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
