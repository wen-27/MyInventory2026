using MyInventory2026.src.Modules.Provider.Application.Interfaces;
using MyInventory2026.src.Modules.Provider.Domain.Aggregate;
using MyInventory2026.src.Modules.Provider.Domain.Repositories;
using MyInventory2026.src.Modules.Provider.Domain.ValueObject;
using MyInventory2026.src.Shared.IUnitOfWork;

namespace MyInventory2026.src.Modules.Provider.Application.Services;

public sealed class ProviderService : IProviderService
{
    private readonly IProviderRepository _providerRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ProviderService(IProviderRepository providerRepository, IUnitOfWork unitOfWork)
    {
        _providerRepository = providerRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Provider> CreateAsync(string id, string name, CancellationToken cancellationToken = default)
    {
        var providerId = ProviderId.Create(id);
        var existingProvider = await _providerRepository.FindByIdAsync(providerId, cancellationToken);

        if (existingProvider is not null)
        {
            throw new InvalidOperationException($"Provider with id '{id}' already exists.");
        }

        var provider = Provider.Create(id, name);
        await _providerRepository.AddAsync(provider, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return provider;
    }

    public Task<Provider?> GetByIdAsync(string id, CancellationToken cancellationToken = default)
    {
        return _providerRepository.FindByIdAsync(ProviderId.Create(id), cancellationToken);
    }

    public Task<IReadOnlyCollection<Provider>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return _providerRepository.FindAllAsync(cancellationToken);
    }

 
    public async Task UpdateAsync(string id, string name, CancellationToken cancellationToken = default)
    {
        var providerId = ProviderId.Create(id);
        var existingProvider = await _providerRepository.FindByIdAsync(providerId, cancellationToken);

        if (existingProvider is null)
        {
            throw new KeyNotFoundException($"Provider with id '{id}' was not found.");
        }

        var updatedProvider = Provider.Create(id, name);
        await _providerRepository.UpdateAsync(updatedProvider, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

   
    public async Task DeleteAsync(string id, CancellationToken cancellationToken = default)
    {
        var providerId = ProviderId.Create(id);
        var wasDeleted = await _providerRepository.DeleteByIdAsync(providerId, cancellationToken);

        if (!wasDeleted)
        {
            throw new KeyNotFoundException($"Provider with id '{id}' was not found.");
        }

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}