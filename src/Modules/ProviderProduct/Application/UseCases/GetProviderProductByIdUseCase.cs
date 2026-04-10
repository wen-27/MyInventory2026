using MyInventory2026.src.Modules.ProviderProduct.Domain.Repositories;
using ProviderProductAggregate = MyInventory2026.src.Modules.ProviderProduct.Domain.Aggregate.ProviderProduct;
using ProviderProductProductId = MyInventory2026.src.Modules.ProviderProduct.Domain.ValueObject.ProviderProductProductId;
using ProviderProductProviderId = MyInventory2026.src.Modules.ProviderProduct.Domain.ValueObject.ProviderProductProviderId;

namespace MyInventory2026.src.Modules.ProviderProduct.Application.UseCases;

public sealed class GetProviderProductByIdUseCase
{
    private readonly IProviderProductRepository _providerProductRepository;

    public GetProviderProductByIdUseCase(IProviderProductRepository providerProductRepository)
    {
        _providerProductRepository = providerProductRepository;
    }

    public Task<ProviderProductAggregate?> ExecuteAsync(
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