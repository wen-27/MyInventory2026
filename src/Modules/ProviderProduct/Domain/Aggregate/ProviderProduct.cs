using MyInventory2026.src.Modules.ProviderProduct.Domain.ValueObject;

namespace MyInventory2026.src.Modules.ProviderProduct.Domain.Aggregate;

public sealed class ProviderProduct
{
    public ProviderProductProductId Id { get; private set; }
    public ProviderProductProviderId ProviderId { get; private set; }

    private ProviderProduct(ProviderProductProductId id, ProviderProductProviderId providerId)
    {
        Id = id;
        ProviderId = providerId;
    }
    public static ProviderProduct Create(int productId, int providerId)
    {
        return new ProviderProduct(
            ProviderProductProductId.Create(productId),
            ProviderProductProviderId.Create(providerId)
        );
    }
    public void Update(int productId, int providerId)
    {
    Id = ProviderProductProductId.Create(productId);
    ProviderId = ProviderProductProviderId.Create(providerId);
    }
}