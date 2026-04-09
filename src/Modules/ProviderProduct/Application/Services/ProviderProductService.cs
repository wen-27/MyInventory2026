using MyInventory2026.src.Modules.ProviderProduct.Application.Interfaces;
using MyInventory2026.src.Modules.ProviderProduct.Domain.Aggregate;
using MyInventory2026.src.Modules.ProviderProduct.Domain.Repositories;
using MyInventory2026.src.Modules.ProviderProduct.Domain.ValueObject;
using MyInventory2026.src.Shared.Contracts;

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

    public async Task<ProviderProduct> CreateAsync(
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

    public Task<ProviderProduct?> GetByIdsAsync(
        int productId,
        int providerId,
        CancellationToken cancellationToken = default)
    {
        return _providerProductRepository.FindByIdsAsync(
            ProviderProductProductId.Create(productId),
            ProviderProductProviderId.Create(providerId),
            cancellationToken);
    }

    public Task<IReadOnlyCollection<ProviderProduct>> GetAllAsync(
        CancellationToken cancellationToken = default)
    {
        return _providerProductRepository.FindAllAsync(cancellationToken);
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
    public async Task UpdateAsync(
        int productId,
        int providerId,
        CancellationToken cancellationToken = default)
    {
        var existing = await _providerProductRepository.FindByIdsAsync(
            ProviderProductProductId.Create(productId),
            ProviderProductProviderId.Create(providerId),
            cancellationToken);

        if (existing is null)
            throw new KeyNotFoundException("The provider-product relationship was not found.");

        var target = await _providerProductRepository.FindByIdsAsync(
            ProviderProductProductId.Create(productId),
            ProviderProductProviderId.Create(providerId),
            cancellationToken);

        if (target is not null)
            throw new InvalidOperationException("The new provider-product relationship already exists.");

        existing.Update(productId, providerId);

        await _providerProductRepository.UpdateAsync(existing, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}