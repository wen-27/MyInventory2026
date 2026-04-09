namespace MyInventory2026.src.Modules.ProviderProduct.Domain.ValueObject;

public sealed class ProviderProductProviderId
{
    public int Value { get; }

    private ProviderProductProviderId(int value)
    {
        Value = value;
    }

    public static ProviderProductProviderId Create(int value)
    {
        return new ProviderProductProviderId(value);
    }
}