using MyInventory2026.src.Modules.ProviderProduct.Domain.Aggregate;
using MyInventory2026.src.Modules.ProviderProduct.Domain.ValueObject;

namespace MyInventory2026.src.Modules.ProviderProduct.Domain.Repositories;

public interface IProviderProductRepository
{
    Task AddAsync(ProviderProduct providerProduct, CancellationToken cancellationToken = default);
    Task<ProviderProduct?> FindByIdAsync(ProviderProductProductId id, CancellationToken cancellationToken = default);
    Task<IReadOnlyCollection<ProviderProduct>> FindAllAsync(CancellationToken cancellationToken = default);
    Task UpdateAsync(ProviderProduct providerProduct, CancellationToken cancellationToken = default);
    Task<bool> DeleteByIdAsync(ProviderProductProductId id, CancellationToken cancellationToken = default);
}