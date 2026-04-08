using System.Threading.Tasks;
using MyInventory2026.src.Modules.provider.Domain.Repositories;
using MyInventory2026.src.Modules.Provider.Domain.Aggregates;

namespace MyInventory2026.src.Modules.Provider.Application.UseCases;

public sealed class GetAllProvidersUseCase
{
    private readonly IProviderRepository _providerRepository;

    public GetAllProvidersUseCase(IProviderRepository providerRepository)
    {
        _providerRepository = providerRepository;
    }

    public Task<IReadOnlyCollection<Provider>> ExecuteAsync(CancellationToken cancellationToken = default)
    {
        return _providerRepository.FindAllAsync(cancellationToken);
    }
}