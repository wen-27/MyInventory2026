using MyInventory2026.src.Modules.Provider.Domain.Repositories;
using MyInventory2026.src.Shared.Contracts;
using ProviderAggregate = MyInventory2026.src.Modules.Provider.Domain.Aggregate.Provider;
using ProviderId = MyInventory2026.src.Modules.Provider.Domain.ValueObject.ProviderId;

namespace MyInventory2026.src.Modules.Provider.Application.UseCases;

public sealed class UpdateProviderUseCase
{
    private readonly IProviderRepository _providerRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateProviderUseCase(IProviderRepository providerRepository, IUnitOfWork unitOfWork)
    {
        _providerRepository = providerRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ProviderAggregate> ExecuteAsync(string id, string name, CancellationToken cancellationToken = default)
    {
        var providerId = ProviderId.Create(id);
        var existingProvider = await _providerRepository.FindByIdAsync(providerId, cancellationToken);

        if (existingProvider is null)
            throw new KeyNotFoundException($"Provider with id '{id}' was not found.");

        existingProvider.Update(name);
        await _providerRepository.UpdateAsync(existingProvider, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return existingProvider;
    }
}