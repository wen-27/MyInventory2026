namespace MyInventory2026.src.Modules.Product.Domain.ValueObject;

public sealed record ProductStockMax
{
    public int Value { get;}

    private ProductStockMax(int value)
    {
        Value = value;
    }

    public static ProductStockMax Create(int value)
    {
        if (value < 0)
        {
            throw new ArgumentException("El stock máximo del producto no puede ser negativo.", nameof(value));
        }
        return new ProductStockMax(value);
    }
    public override string ToString() => Value.ToString();
}