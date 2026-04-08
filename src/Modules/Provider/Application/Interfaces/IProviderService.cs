using MyInventory2026.src.Modules.Provider.Domain.Aggregate;

namespace MyInventory2026.src.Modules.Provider.Application.Interfaces;

public interface IProviderService
{
    Task<Provider> CreateAsync(string id, string name, CancellationToken cancellationToken = default);
    Task<Provider?> GetByIdAsync(string id, CancellationToken cancellationToken = default);
    Task<IReadOnlyCollection<Provider>> GetAllAsync(CancellationToken cancellationToken = default);
    Task UpdateAsync(string id, string name, CancellationToken cancellationToken = default);
    Task DeleteAsync(string id, string cancellationToken = default);
}