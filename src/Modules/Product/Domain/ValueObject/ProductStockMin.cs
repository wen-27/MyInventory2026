namespace MyInventory2026.src.Modules.Product.Domain.ValueObject;

public sealed record ProductStockMin
{
    public int Value { get;}

    private ProductStockMin(int value)
    {
        Value = value;
    }
    
    public static ProductStockMin Create(int value)
    {
        if (value < 0)
        {
            throw new ArgumentException("El stock mínimo del producto no puede ser negativo.", nameof(value));
        }
        return new ProductStockMin(value);
    }
    public override string ToString() => Value.ToString();
}