using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyInventory2026.src.Modules.ProviderProduct.Infrastructure.Entity;

namespace MyInventory2026.src.Modules.ProviderProduct.Infrastructure.Entity;

public sealed class ProviderProductEntityConfiguration : IEntityTypeConfiguration<ProviderProductEntity>
{
    public void Configure(EntityTypeBuilder<ProviderProductEntity> builder)
    {
        builder.ToTable("provider_products");

        builder.HasKey(x => new { x.ProductId, x.ProviderId });

        builder.Property(x => x.ProductId)
            .IsRequired();

        builder.Property(x => x.ProviderId)
            .IsRequired();
    }
}