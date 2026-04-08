using MyInventory2026.src.Modules.Provider.Domain.Aggregate;
using MyInventory2026.src.Modules.Provider.Domain.ValueObject;
namespace MyInventory2026.src.Modules.Provider.Domain.Repositories;

public interface IProviderRepository
{
    Task AddAsync(Provider provider, CancellationToken cancellationToken = default);
    Task<Provider?> FindByIdAsync(ProviderId id, CancellationToken cancellationToken = default);
    Task<IReadOnlyCollection<Provider>> FindAllAsync(CancellationToken cancellationToken = default);
    Task UpdateAsync(Provider provider, CancellationToken cancellationToken = default);
    Task<bool> DeleteByIdAsync(ProviderId id, CancellationToken cancellationToken = default);
}