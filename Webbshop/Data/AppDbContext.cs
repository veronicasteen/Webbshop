using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Webbshop.Models;

namespace Webbshop.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<AccountProduct> AccountProducts { get; set; }


        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Define composite primary key for AccountProduct
            modelBuilder.Entity<AccountProduct>()
                .HasKey(ap => new { ap.AccountID, ap.ProductID });

            // Configure relationships
            modelBuilder.Entity<AccountProduct>()
                .HasOne(ap => ap.Account)
                .WithMany(a => a.AccountProducts)
                .HasForeignKey(ap => ap.AccountID);

            modelBuilder.Entity<AccountProduct>()
                .HasOne(ap => ap.Product)
                .WithMany(p => p.AccountProducts)
                .HasForeignKey(ap => ap.ProductID);

            base.OnModelCreating(modelBuilder);
        }
    }
}
