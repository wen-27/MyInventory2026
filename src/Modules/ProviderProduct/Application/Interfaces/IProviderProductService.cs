using System.Threading;
using MyInventory2026.src.Modules.ProviderProduct.Domain.Aggregate;

namespace MyInventory2026.src.Modules.ProviderProduct.Application.Interfaces;

public interface IProviderProductService
{
    Task<ProviderProduct> CreateAsync(
        int productId,
        int providerId,
        CancellationToken cancellationToken = default);

    Task<ProviderProduct?> GetByIdsAsync(
        int productId,
        int providerId,
        CancellationToken cancellationToken = default);

    Task<IReadOnlyCollection<ProviderProduct>> GetAllAsync(
        CancellationToken cancellationToken = default);

    Task DeleteAsync(
        int productId,
        int providerId,
        CancellationToken cancellationToken = default);
    
    Task UpdateAsync(
        int productId,
        int providerId,
        CancellationToken cancellationToken = default);
    
}