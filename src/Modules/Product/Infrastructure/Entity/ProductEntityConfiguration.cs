namespace MyInventory2026.src.Modules.Product.Infrastructure.Persistence.Configurations;

public sealed class ProductEntityConfiguration : IEntityTypeConfiguration<ProductEntity>
{
    public void Configure(EntityTypeBuilder<ProductEntity> builder)
    {
        builder.ToTable("products");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedNever();

        builder.Property(x => x.CodeInv)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(x => x.NameProduct)
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(x => x.Stock)
            .IsRequired();

        builder.Property(x => x.StockMin)
            .IsRequired();

        builder.Property(x => x.StockMax)
            .IsRequired();

        builder.HasCheckConstraint("CK_Product_Stock", "Stock >= 0");
        builder.HasCheckConstraint("CK_Product_StockMin", "StockMin >= 0");
        builder.HasCheckConstraint("CK_Product_StockMax", "StockMax >= 0");
        builder.HasCheckConstraint("CK_Product_StockRange", "StockMin <= StockMax");
    }
}