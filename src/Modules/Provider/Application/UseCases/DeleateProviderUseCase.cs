using MyInventory2026.src.Modules.Provider.Domain.Repositories;
using MyInventory2026.src.Modules.Provider.Domain.ValueObject;

namespace MyInventory2026.src.Modules.Provider.Application.UseCases;

public sealed class DeleateProviderUseCase
{
    private readonly IProviderRepository _providerRepository;

    public DeleateProviderUseCase(IProviderRepository providerRepository)
    {
        _providerRepository = providerRepository;
    }

    public async Task<bool> ExecuteAsync(string id, CancellationToken cancellationToken = default)
    {
        var providerId = ProviderId.Create(id);

        var existingProvider = await _providerRepository.FindByIdAsync(providerId, cancellationToken);

        if (existingProvider is null)
        {
            throw new KeyNotFoundException($"Provider with id '{id}' was not found.");
        }

        return await _providerRepository.DeleteByIdAsync(providerId, cancellationToken);
    }
}