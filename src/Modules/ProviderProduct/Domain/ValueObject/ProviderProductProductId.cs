namespace MyInventory2026.src.Modules.ProviderProduct.Domain.ValueObject;

public sealed record ProviderProductProductId
{
    public int Value { get; }

    private ProductId(int value)
    {
        Value = value;
    }

    public static ProductId Create(int value)
    {
        if (value <= 0) throw new ArgumentException("El id del producto debe ser mayor que cero.", nameof(value));
        return new ProductId(value);
    }
    public override string ToString() => Value.ToString();
}