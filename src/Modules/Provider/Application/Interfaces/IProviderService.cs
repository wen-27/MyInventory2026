using System.Threading;
using System.Threading.Tasks;
using MyInventory2026.src.Modules.Provider.Application.Interfaces;

namespace MyInventory2026.src.Modules.Provider.Application.Interfaces;

public interface IProviderService
{
    Task<Provider> CeateAsync(string id, string name, CancellationToken cancellationToken = default);
    Task<Provider> GetByAsync(string id, CancellationToken cancellationToken = default);
    Task<IReadOnlyCollection<Provider>> GetAllAsync(CancellationToken cancellationToken = default);
    Task UpdateAsync(string id, string name, CancellationToken cancellationToken = default);
    Task DeleteAsync(string id, CancellationToken cancellationToken = default);
}