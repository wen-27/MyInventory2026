using MyInventory2026.src.Modules.Provider.Domain.Repositories;
using MyInventory2026.src.Shared.Contracts;
using ProviderAggregate = MyInventory2026.src.Modules.Provider.Domain.Aggregate.Provider;
using ProviderId = MyInventory2026.src.Modules.Provider.Domain.ValueObject.ProviderId;

namespace MyInventory2026.src.Modules.Provider.Application.UseCases;

public sealed class CreateProviderUseCase
{
    private readonly IProviderRepository _providerRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateProviderUseCase(IProviderRepository providerRepository, IUnitOfWork unitOfWork)
    {
        _providerRepository = providerRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ProviderAggregate> ExecuteAsync(string id, string name, CancellationToken cancellationToken = default)
    {
        var providerId = ProviderId.Create(id);
        var existingProvider = await _providerRepository.FindByIdAsync(providerId, cancellationToken);

        if (existingProvider is not null)
            throw new InvalidOperationException($"Provider with id '{id}' already exists.");

        var provider = ProviderAggregate.Create(id, name);
        await _providerRepository.AddAsync(provider, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return provider;
    }
}