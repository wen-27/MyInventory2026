using MyInventory2026.src.Modules.ProviderProduct.Application.Interfaces;
using MyInventory2026.src.Modules.ProviderProduct.Domain.Repositories;
using MyInventory2026.src.Shared.Contracts;
using ProviderProductAggregate = MyInventory2026.src.Modules.ProviderProduct.Domain.Aggregate.ProviderProduct;
using ProviderProductProductId = MyInventory2026.src.Modules.ProviderProduct.Domain.ValueObject.ProviderProductProductId;
using ProviderProductProviderId = MyInventory2026.src.Modules.ProviderProduct.Domain.ValueObject.ProviderProductProviderId;

namespace MyInventory2026.src.Modules.ProviderProduct.Application.Services;

public sealed class ProviderProductService : IProviderProductService
{
    private readonly IProviderProductRepository _providerProductRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ProviderProductService(
        IProviderProductRepository providerProductRepository,
        IUnitOfWork unitOfWork)
    {
        _providerProductRepository = providerProductRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ProviderProductAggregate> CreateAsync(
        int productId,
        int providerId,
        CancellationToken cancellationToken = default)
    {
        var productIdVo = ProviderProductProductId.Create(productId);
        var providerIdVo = ProviderProductProviderId.Create(providerId);

        var existing = await _providerProductRepository.FindByIdsAsync(productIdVo, providerIdVo, cancellationToken);
        if (existing is not null)
            throw new InvalidOperationException("The provider-product relationship already exists.");

        var providerProduct = ProviderProductAggregate.Create(productId, providerId);
        await _providerProductRepository.AddAsync(providerProduct, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return providerProduct;
    }

    public Task<ProviderProductAggregate?> GetByIdsAsync(
        int productId,
        int providerId,
        CancellationToken cancellationToken = default)
    {
        return _providerProductRepository.FindByIdsAsync(
            ProviderProductProductId.Create(productId),
            ProviderProductProviderId.Create(providerId),
            cancellationToken);
    }

    public Task<IReadOnlyCollection<ProviderProductAggregate>> GetAllAsync(
        CancellationToken cancellationToken = default)
    {
        return _providerProductRepository.FindAllAsync(cancellationToken);
    }

    public async Task UpdateAsync(
        int productId,
        int providerId,
        int newProductId,
        int newProviderId,
        CancellationToken cancellationToken = default)
    {
        var providerProduct = await _providerProductRepository.FindByIdsAsync(
            ProviderProductProductId.Create(productId),
            ProviderProductProviderId.Create(providerId),
            cancellationToken);

        if (providerProduct is null)
            throw new KeyNotFoundException("The provider-product relationship was not found.");

        var target = await _providerProductRepository.FindByIdsAsync(
            ProviderProductProductId.Create(newProductId),
            ProviderProductProviderId.Create(newProviderId),
            cancellationToken);

        if (target is not null && !(productId == newProductId && providerId == newProviderId))
            throw new InvalidOperationException("The new provider-product relationship already exists.");

        providerProduct.Update(newProductId, newProviderId);
        await _providerProductRepository.UpdateAsync(providerProduct, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(
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