using MyInventory2026.src.Modules.ProviderProduct.Domain.Repositories;
using MyInventory2026.src.Modules.ProviderProduct.Domain.ValueObject;
using MyInventory2026.src.Shared.Contracts;

namespace MyInventory2026.src.Modules.ProviderProduct.Application.UseCases;

public sealed class DeleteProviderProductUseCase
{
    private readonly IProviderProductRepository _providerProductRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteProviderProductUseCase(
        IProviderProductRepository providerProductRepository,
        IUnitOfWork unitOfWork)
    {
        _providerProductRepository = providerProductRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task ExecuteAsync(
        int productId,
        int providerId,
        CancellationToken cancellationToken = default)
    {
        var deleted = await _providerProductRepository.DeleteByIdsAsync(
            ProviderProductProductId.Create(productId),
            ProviderProductProviderId.Create(providerId),
            cancellationToken);

        if (!deleted)
            throw new KeyNotFoundException("The provider-product relationship was not found.");

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}