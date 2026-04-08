using MyInventory2026.src.Modules.Provider.Domain.Repositories;
using MyInventory2026.src.Modules.Provider.Domain.Aggregate;
using MyInventory2026.src.Modules.Provider.Domain.ValueObject;

namespace MyInventory2026.src.Modules.Provider.Application.UseCases;

public sealed class UpdateProviderUseCase
{
    private readonly IProviderRepository _providerRepository;

    public UpdateProviderUseCase(IProviderRepository providerRepository)
    {
        _providerRepository = providerRepository;
    }

    public async Task<Provider> ExecuteAsync(string id, string name, CancellationToken cancellationToken = default)
    {
        var providerId = ProviderId.Create(id);
        var existingProvider = await _providerRepository.FindByIdAsync(providerId, cancellationToken);

        if (existingProvider is null)
        {
            throw new KeyNotFoundException($"Provider with id '{providerId}' was not found.");
        }

        var updatedProvider = Provider.Create(id, name);
        await _providerRepository.UpdateAsync(updatedProvider, cancellationToken);
        return updatedProvider;
    }
}