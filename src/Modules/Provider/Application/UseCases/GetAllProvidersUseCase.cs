using MyInventory2026.src.Modules.Provider.Domain.Repositories;
using ProviderAggregate = MyInventory2026.src.Modules.Provider.Domain.Provider.Provider;

namespace MyInventory2026.src.Modules.Provider.Application.UseCases;

public sealed class GetAllProvidersUseCase
{
    private readonly IProviderRepository _providerRepository;

    public GetAllProvidersUseCase(IProviderRepository providerRepository)
    {
        _providerRepository = providerRepository;
    }

    public Task<IReadOnlyCollection<ProviderAggregate>> ExecuteAsync(
        CancellationToken cancellationToken = default)
    {
        return _providerRepository.FindAllAsync(cancellationToken);
    }
}