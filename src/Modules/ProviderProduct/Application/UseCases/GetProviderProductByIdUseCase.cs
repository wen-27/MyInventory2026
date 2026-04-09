using MyInventory2026.src.Modules.ProviderProduct.Domain.Repositories;
using MyInventory2026.src.Modules.ProviderProduct.Domain.ValueObject;
using ProviderProductAggregate = MyInventory2026.src.Modules.ProviderProduct.Domain.ProviderProduct.ProviderProduct;

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