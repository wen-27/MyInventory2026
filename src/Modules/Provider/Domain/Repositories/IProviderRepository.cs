using MyInventory2026.src.Modules.Provider.Domain.Aggregate;
using MyInventory2026.src.Modules.Provider.Domain.ValueObject;

namespace MyInventory2026.src.Modules.Provider.Domain.Repositories;

public interface IProviderRepository
{
    Task AddAsync(ProviderAggregate provider, CancellationToken cancellationToken = default);
    Task<ProviderAggregate?> FindByIdAsync(ProviderId id, CancellationToken cancellationToken = default);
    Task<IReadOnlyCollection<ProviderAggregate>> FindAllAsync(CancellationToken cancellationToken = default);
    Task UpdateAsync(ProviderAggregate provider, CancellationToken cancellationToken = default);
    Task<bool> DeleteByIdAsync(ProviderId id, CancellationToken cancellationToken = default);
}