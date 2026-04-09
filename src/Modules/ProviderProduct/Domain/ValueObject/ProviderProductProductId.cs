namespace MyInventory2026.src.Modules.ProviderProduct.Domain.ValueObject;

public sealed class ProviderProductProductId
{
    public int Value { get; }

    private ProviderProductProductId(int value)
    {
        Value = value;
    }

    public static ProviderProductProductId Create(int value)
    {
        return new ProviderProductProductId(value);
    }
}