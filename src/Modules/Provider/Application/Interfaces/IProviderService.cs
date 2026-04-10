using ProviderAggregate = MyInventory2026.src.Modules.Provider.Domain.Aggregate.Provider;

namespace MyInventory2026.src.Modules.Provider.Application.Interfaces;

public interface IProviderService
{
    Task<ProviderAggregate> CreateAsync(string id, string name, CancellationToken cancellationToken = default);
    Task<ProviderAggregate?> GetByIdAsync(string id, CancellationToken cancellationToken = default);
    Task<IReadOnlyCollection<ProviderAggregate>> GetAllAsync(CancellationToken cancellationToken = default);
    Task UpdateAsync(string id, string name, CancellationToken cancellationToken = default);
    Task DeleteAsync(string id, CancellationToken cancellationToken = default);
}