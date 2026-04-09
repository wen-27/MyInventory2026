using MyInventory2026.src.Modules.ProviderProduct.Domain.Aggregate;
using MyInventory2026.src.Modules.ProviderProduct.Domain.Repositories;

namespace MyInventory2026.src.Modules.ProviderProduct.Application.UseCases;

public sealed class GetAllProviderProductsUseCase
{
    private readonly IProviderProductRepository _providerProductRepository;

    public GetAllProviderProductsUseCase(IProviderProductRepository providerProductRepository)
    {
        _providerProductRepository = providerProductRepository;
    }

    public Task<IReadOnlyCollection<ProviderProduct>> ExecuteAsync(
        CancellationToken cancellationToken = default)
    {
        return _providerProductRepository.FindAllAsync(cancellationToken);
    }
}