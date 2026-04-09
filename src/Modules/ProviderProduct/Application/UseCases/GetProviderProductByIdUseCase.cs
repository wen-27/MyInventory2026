using MyInventory2026.src.Modules.ProviderProduct.Domain.Aggregate;
using MyInventory2026.src.Modules.ProviderProduct.Domain.Repositories;
using MyInventory2026.src.Modules.ProviderProduct.Domain.ValueObject;

namespace MyInventory2026.src.Modules.ProviderProduct.Application.UseCases;

public sealed class GetProviderProductByIdsUseCase
{
    private readonly IProviderProductRepository _providerProductRepository;

    public GetProviderProductByIdsUseCase(IProviderProductRepository providerProductRepository)
    {
        _providerProductRepository = providerProductRepository;
    }

    public Task<ProviderProduct?> ExecuteAsync(
        int productId,
        int providerId,
        CancellationToken cancellationToken = default)
    {
        return _providerProductRepository.FindByIdsAsync(
            ProviderProductProductId.Create(productId),
            ProviderProductProviderId.Create(providerId),
            cancellationToken);
    }
}