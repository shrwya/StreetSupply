using Microsoft.EntityFrameworkCore;
using StreetSupply.Models;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace StreetSupply.Data
{
    public class StreetSupplyDbContext : DbContext
    {
        public StreetSupplyDbContext(DbContextOptions<StreetSupplyDbContext> options)
            : base(options)
        {
        }

        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<Hawker> Hawkers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<OrderRequest> OrderRequests { get; set; }
        public DbSet<OrderHistory> OrderHistories { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderRequest>()
                .Property(o => o.Status)
                .HasDefaultValue("Pending");

            modelBuilder.Entity<Vendor>()
                .HasMany(v => v.Products)
                .WithOne(p => p.Vendor)
                .HasForeignKey(p => p.VendorId);

            modelBuilder.Entity<Vendor>()
                .HasMany(v => v.OrdersReceived)
                .WithOne(o => o.Vendor)
                .HasForeignKey(o => o.VendorId);

            modelBuilder.Entity<Hawker>()
                .HasMany(h => h.OrdersPlaced)
                .WithOne(o => o.Hawker)
                .HasForeignKey(o => o.HawkerId);
        }
    }
}
