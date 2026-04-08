using MyInventory2026.src.Modules.provider.Domain.Repositories;
using MyInventory2026.src.Modules.Provider.Domain.ValueObject;

namespace MyInventory2026.src.Modules.Provider.Application.UseCases;

public sealed class DeleteProviderUseCase
{
    private readonly IProviderRepository _providerRepository;
    public DeleteProviderUseCase(IProviderRepository providerRepository)
    {
        _providerRepository = providerRepository;   
    }
    public async Task<bool> ExecuteAsync(ProviderId id, CancellationToken cancellationToken = default)
    {
        var ProviderId = ProviderId.Create(id);
        var provider = await _providerRepository.FindByIdAsync(ProviderId, cancellationToken);
        if(existingProvider is null)
        {
            return false;
        }

        return await _providerRepository.DeleteByIdAsync(ProviderId, cancellationToken);
    }
}