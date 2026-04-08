using MyInventory2026.src.Modules.Provider.Domain.Aggregate;
using MyInventory2026.src.Modules.Provider.Domain.Repositories;

namespace MyInventory2026.src.Modules.Provider.Application.UseCases;

public sealed class GetAllProvidersUseCase
{
    private readonly IProviderRepository _providerRepository;

    public GetAllProvidersUseCase(IProviderRepository providerRepository)
    {
        _providerRepository = providerRepository;
    }

    public Task<IReadOnlyCollection<ProviderAggregate>> ExecuteAsync(CancellationToken cancellationToken = default)
    {
        return _providerRepository.FindAllAsync(cancellationToken);
    }
}