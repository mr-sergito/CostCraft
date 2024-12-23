using CostCraft.Api.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CostCraft.Api.Infrastructure.Data
{
    public class CostCraftDbContext(DbContextOptions<CostCraftDbContext> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<Labor> Labors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Labor>()
                .Property(l => l.TimePayRate)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<Labor>()
                .Property(l => l.TimeWorked)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<Material>()
                .Property(m => m.PurchasedAmount)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<Material>()
                .Property(m => m.PurchasedPrice)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<Material>()
                .Property(m => m.UsedAmount)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<Product>()
                .Property(p => p.ProfitMarginPercentage)
                .HasColumnType("decimal(18, 2)");
        }
    }
}
