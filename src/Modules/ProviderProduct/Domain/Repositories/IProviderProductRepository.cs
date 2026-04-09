using MyInventory2026.src.Modules.ProviderProduct.Domain;
using MyInventory2026.src.Modules.ProviderProduct.Domain.ValueObject;

namespace MyInventory2026.src.Modules.ProviderProduct.Domain.Repositories;

public interface IProviderProductRepository
{
    Task AddAsync(ProviderProduct providerProduct, CancellationToken cancellationToken = default);

    Task<ProviderProduct?> FindByIdsAsync(
        ProviderProductProductId productId,
        ProviderProductProviderId providerId,
        CancellationToken cancellationToken = default);

    Task<IReadOnlyCollection<ProviderProduct>> FindAllAsync(
        CancellationToken cancellationToken = default);

    Task UpdateAsync(ProviderProduct providerProduct, CancellationToken cancellationToken = default);

    Task<bool> DeleteByIdsAsync(
        ProviderProductProductId productId,
        ProviderProductProviderId providerId,
        CancellationToken cancellationToken = default);
}