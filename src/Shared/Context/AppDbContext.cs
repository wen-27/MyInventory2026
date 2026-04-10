using Microsoft.EntityFrameworkCore;
using MyInventory2026.src.Modules.Provider.Infrastructure.Entity;
using MyInventory2026.src.Modules.Product.Infrastructure.Entity;
using MyInventory2026.src.Modules.ProviderProduct.Infrastructure.Entity;

namespace MyInventory2026.src.Shared.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<ProviderEntity> Providers => Set<ProviderEntity>();
    public DbSet<ProductEntity> Products => Set<ProductEntity>();
    public DbSet<ProviderProductEntity> ProviderProducts => Set<ProviderProductEntity>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}