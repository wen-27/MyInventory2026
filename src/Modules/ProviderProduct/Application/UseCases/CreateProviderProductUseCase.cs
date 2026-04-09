using MyInventory2026.src.Modules.ProviderProduct.Domain;
using MyInventory2026.src.Modules.ProviderProduct.Domain.Repositories;
using MyInventory2026.src.Modules.ProviderProduct.Domain.ValueObject;
using MyInventory2026.src.Shared.Contracts;

namespace MyInventory2026.src.Modules.ProviderProduct.Application.UseCases;

public sealed class CreateProviderProductUseCase
{
    private readonly IProviderProductRepository _providerProductRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateProviderProductUseCase(
        IProviderProductRepository providerProductRepository,
        IUnitOfWork unitOfWork)
    {
        _providerProductRepository = providerProductRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ProviderProduct> ExecuteAsync(
        int productId,
        int providerId,
        CancellationToken cancellationToken = default)
    {
        var productIdVo = ProviderProductProductId.Create(productId);
        var providerIdVo = ProviderProductProviderId.Create(providerId);

        var existing = await _providerProductRepository.FindByIdsAsync(
            productIdVo,
            providerIdVo,
            cancellationToken);

        if (existing is not null)
            throw new InvalidOperationException("The provider-product relationship already exists.");

        var providerProduct = ProviderProduct.Create(productId, providerId);

        await _providerProductRepository.AddAsync(providerProduct, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return providerProduct;
    }
}
