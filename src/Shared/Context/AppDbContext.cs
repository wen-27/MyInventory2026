using Microsoft.EntityFrameworkCore;
using MyInventory2026.src.Modules.Provider.Infrastructure.Entity;

namespace MyInventory2026.src.Shared.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    public DbSet<ProviderEntity> Providers => Set<ProviderEntity>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}