using MyInventory2026.src.Modules.ProviderProduct.Domain.Repositories;
using ProviderProductAggregate = MyInventory2026.src.Modules.ProviderProduct.Domain.ProviderProduct.ProviderProduct;

namespace MyInventory2026.src.Modules.ProviderProduct.Application.UseCases;

public sealed class GetAllProviderProductUseCase
{
    private readonly IProviderProductRepository _providerProductRepository;

    public GetAllProviderProductUseCase(IProviderProductRepository providerProductRepository)
    {
        _providerProductRepository = providerProductRepository;
    }

    public Task<IReadOnlyCollection<ProviderProductAggregate>> ExecuteAsync(
        CancellationToken cancellationToken = default)
    {
        return _providerProductRepository.FindAllAsync(cancellationToken);
    }
}