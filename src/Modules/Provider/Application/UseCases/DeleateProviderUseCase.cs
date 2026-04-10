using MyInventory2026.src.Modules.Provider.Domain.Repositories;
using MyInventory2026.src.Shared.Contracts;
using ProviderId = MyInventory2026.src.Modules.Provider.Domain.ValueObject.ProviderId;

namespace MyInventory2026.src.Modules.Provider.Application.UseCases;

public sealed class DeleteProviderUseCase
{
    private readonly IProviderRepository _providerRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteProviderUseCase(IProviderRepository providerRepository, IUnitOfWork unitOfWork)
    {
        _providerRepository = providerRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> ExecuteAsync(string id, CancellationToken cancellationToken = default)
    {
        var providerId = ProviderId.Create(id);

        var existingProvider = await _providerRepository.FindByIdAsync(providerId, cancellationToken);
        if (existingProvider is null)
            throw new KeyNotFoundException($"Provider with id '{id}' was not found.");

        var wasDeleted = await _providerRepository.DeleteByIdAsync(providerId, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return wasDeleted;
    }
}