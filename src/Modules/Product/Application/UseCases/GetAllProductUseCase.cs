using MyInventory2026.src.Modules.Product.Domain.Aggregate;
using MyInventory2026.src.Modules.Product.Domain.Repositories;

namespace MyInventory2026.src.Modules.Product.Application.UseCases;

public sealed class GetAllProductsUseCase
{
    private readonly IProductRepository _productRepository;

    public GetAllProductsUseCase(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public Task<IReadOnlyCollection<Product>> ExecuteAsync(
        CancellationToken cancellationToken = default)
    {
        return _productRepository.FindAllAsync(cancellationToken);
    }
}