using MyInventory2026.src.Modules.ProviderProduct.Domain.Repositories;
using MyInventory2026.src.Modules.ProviderProduct.Domain.ValueObject;
using MyInventory2026.src.Shared.Contracts;

namespace MyInventory2026.src.Modules.ProviderProduct.Application.UseCases;

public sealed class UpdateProviderProductUseCase
{
    private readonly IProviderProductRepository _providerProductRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateProviderProductUseCase(
        IProviderProductRepository providerProductRepository,
        IUnitOfWork unitOfWork)
    {
        _providerProductRepository = providerProductRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task ExecuteAsync(
        int productId,
        int providerId,
        int newProductId,
        int newProviderId,
        CancellationToken cancellationToken = default)
    {
        var existing = await _providerProductRepository.FindByIdsAsync(
            ProviderProductProductId.Create(productId),
            ProviderProductProviderId.Create(providerId),
            cancellationToken);

        if (existing is null)
            throw new KeyNotFoundException("The provider-product relationship was not found.");

        var target = await _providerProductRepository.FindByIdsAsync(
            ProviderProductProductId.Create(newProductId),
            ProviderProductProviderId.Create(newProviderId),
            cancellationToken);

        if (target is not null && !(productId == newProductId && providerId == newProviderId))
            throw new InvalidOperationException("The new provider-product relationship already exists.");

        existing.Update(newProductId, newProviderId);

        await _providerProductRepository.UpdateAsync(existing, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}