namespace MyInventory2026.src.Modules.Product.Domain.ValueObject;

public sealed record ProductStock
{
    public int Value {get;}

    private ProductStock(int value)
    {
        Value = value;
    }

    public static ProductStock Create(int value)
    {
        if (value < 0) 
        {
throw new ArgumentException("El stock del producto no puede ser negativo.", nameof(value));
        }
        return new ProductStock(value);
    }
    public override string ToString() => Value.ToString();
}