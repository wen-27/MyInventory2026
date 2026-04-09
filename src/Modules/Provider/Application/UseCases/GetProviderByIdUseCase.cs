using MyInventory2026.src.Modules.Provider.Domain.Repositories;
using MyInventory2026.src.Modules.Provider.Domain.ValueObject;
using ProviderAggregate = MyInventory2026.src.Modules.Provider.Domain.Provider.Provider;

namespace MyInventory2026.src.Modules.Provider.Application.UseCases;

public sealed class GetProviderByIdUseCase
{
    private readonly IProviderRepository _providerRepository;

    public GetProviderByIdUseCase(IProviderRepository providerRepository)
    {
        _providerRepository = providerRepository;
    }

    public Task<ProviderAggregate?> ExecuteAsync(
        int id,
        CancellationToken cancellationToken = default)
    {
        return _providerRepository.FindByIdAsync(ProviderId.Create(id), cancellationToken);
    }
}