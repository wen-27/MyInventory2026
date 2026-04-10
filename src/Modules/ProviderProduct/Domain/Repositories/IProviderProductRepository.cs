using ProviderProductAggregate = MyInventory2026.src.Modules.ProviderProduct.Domain.Aggregate.ProviderProduct;
using ProviderProductProductId = MyInventory2026.src.Modules.ProviderProduct.Domain.ValueObject.ProviderProductProductId;
using ProviderProductProviderId = MyInventory2026.src.Modules.ProviderProduct.Domain.ValueObject.ProviderProductProviderId;

namespace MyInventory2026.src.Modules.ProviderProduct.Domain.Repositories;

public interface IProviderProductRepository
{
    Task AddAsync(ProviderProductAggregate providerProduct, CancellationToken cancellationToken = default);
    Task<ProviderProductAggregate?> FindByIdsAsync(
        ProviderProductProductId productId,
        ProviderProductProviderId providerId,
        CancellationToken cancellationToken = default);
    Task<IReadOnlyCollection<ProviderProductAggregate>> FindAllAsync(CancellationToken cancellationToken = default);
    Task UpdateAsync(ProviderProductAggregate providerProduct, CancellationToken cancellationToken = default);
    Task<bool> DeleteByIdsAsync(
        ProviderProductProductId productId,
        ProviderProductProviderId providerId,
        CancellationToken cancellationToken = default);
}