namespace MyInventory2026.src.Modules.Product.Infrastructure.Entity;

public sealed class ProductEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string CodeInv { get; set; } = string.Empty;
    public int StockMin { get; set; }
    public int StockMax { get; set; }
    public int Stock { get; set; }
}