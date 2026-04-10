using ProviderProductAggregate = MyInventory2026.src.Modules.ProviderProduct.Domain.Aggregate.ProviderProduct;

namespace MyInventory2026.src.Modules.ProviderProduct.Application.Interfaces;

public interface IProviderProductService
{
    Task<ProviderProductAggregate> CreateAsync(
        int productId,
        int providerId,
        CancellationToken cancellationToken = default);

    Task<ProviderProductAggregate?> GetByIdsAsync(
        int productId,
        int providerId,
        CancellationToken cancellationToken = default);

    Task<IReadOnlyCollection<ProviderProductAggregate>> GetAllAsync(
        CancellationToken cancellationToken = default);

    Task UpdateAsync(
        int productId,
        int providerId,
        int newProductId,
        int newProviderId,
        CancellationToken cancellationToken = default);

    Task DeleteAsync(
        int productId,
        int providerId,
        CancellationToken cancellationToken = default);
}