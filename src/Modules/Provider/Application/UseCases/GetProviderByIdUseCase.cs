using MyInventory2026.src.Modules.provider.Domain.Repositories;
using MyInventory2026.src.Modules.Provider.Domain.Aggregates;
using MyInventory2026.src.Modules.Provider.Domain.ValueObject;

namespace MyInventory2026.src.Modules.Provider.Application.UseCases;

public sealed class GetProviderByIdUseCase
{
    private readonly IProviderRepository _providerRepository;

    public GetProviderByIdUseCase(IProviderRepository providerRepository)
    {
        _providerRepository = providerRepository;
    }

    public Task<Provider?> ExecuteAsync(string id, CancellationToken cancellationToken = default)
    {
        return _providerRepository.FindByIdAsync(ProviderId.Create(id), cancellationToken);
    }
}