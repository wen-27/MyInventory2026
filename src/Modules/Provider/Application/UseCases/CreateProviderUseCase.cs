using MyInventory2026.src.Modules.Provider.Domain.Repositories;
using MyInventory2026.src.Modules.Provider.Domain.Aggregate;
using MyInventory2026.src.Modules.Provider.Domain.Repositories;
using MyInventory2026.src.Modules.Provider.Domain.ValueObject;

namespace MyInventory2026.src.Modules.Provider.Application.UseCases;

public sealed class CreateProviderUseCases
{
    private readonly IProviderRepository _providerRepository;
    public CreateProviderUseCases(IProviderRepository providerRepository)
    {
        _providerRepository = providerRepository;   
    }
    public async Task<Provider> ExecuteAsync(string id, string name, CancellationToken cancellationToken = default)
    {
        var provider = Provider.Create(id);
        var existingProvider = await _providerRepository.FindByIdAsync(provider.Id, cancellationToken);
        if(existingProvider is not null)
        {
            throw new InvalidOperationException($"provider with id {id} already exists");
        }

        var provider = Provider.Create(id, name);
        await _providerRepository.AddAsync(provider, cancellationToken);
        return provider;
    }
}