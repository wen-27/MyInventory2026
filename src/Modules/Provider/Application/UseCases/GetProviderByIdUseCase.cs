using MyInventory2026.src.Modules.Provider.Domain.Aggregate;
using MyInventory2026.src.Modules.Provider.Domain.Repositories;
using MyInventory2026.src.Modules.Provider.Domain.ValueObject;

namespace MyInventory2026.src.Modules.Provider.Application.UseCases;

public sealed class GetProviderByIdUseCase
{
    private readonly IProviderRepository _providerRepository;

    public GetProviderByIdUseCase(IProviderRepository providerRepository)
    {
        _providerRepository = providerRepository;
    }

    public Task<ProviderAggregate?> ExecuteAsync(string id, CancellationToken cancellationToken = default)
    {
        return _providerRepository.FindByIdAsync(ProviderId.Create(id), cancellationToken);
    }
}