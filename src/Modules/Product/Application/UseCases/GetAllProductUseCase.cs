using MyInventory2026.src.Modules.Product.Domain.Repositories;
using ProductAggregate = MyInventory2026.src.Modules.Product.Domain.Aggregate.Product;

namespace MyInventory2026.src.Modules.Product.Application.UseCases;

public sealed class GetAllProductUseCase
{
    private readonly IProductRepository _productRepository;

    public GetAllProductUseCase(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public Task<IReadOnlyCollection<ProductAggregate>> ExecuteAsync(
        CancellationToken cancellationToken = default)
    {
        return _productRepository.FindAllAsync(cancellationToken);
    }
}