using CostCraft.Domain.ProductAggregate;
using CostCraft.Domain.UserAggregate;
using Microsoft.EntityFrameworkCore;

namespace CostCraft.Infrastructure.Persistence;

public class CostCraftDbCcontext : DbContext
{
    public CostCraftDbCcontext(DbContextOptions<CostCraftDbCcontext> options)
        : base(options)
    {
    }

    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Product> Products { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .ApplyConfigurationsFromAssembly(typeof(CostCraftDbCcontext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}
