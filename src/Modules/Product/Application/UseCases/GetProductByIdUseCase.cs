using MyInventory2026.src.Modules.Product.Domain.Repositories;
using ProductAggregate = MyInventory2026.src.Modules.Product.Domain.Aggregate.Product;
using ProductId = MyInventory2026.src.Modules.Product.Domain.ValueObject.ProductId;

namespace MyInventory2026.src.Modules.Product.Application.UseCases;

public sealed class GetProductByIdUseCase
{
    private readonly IProductRepository _productRepository;

    public GetProductByIdUseCase(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public Task<ProductAggregate?> ExecuteAsync(
        int id,
        CancellationToken cancellationToken = default)
    {
        return _productRepository.FindByIdAsync(ProductId.Create(id), cancellationToken);
    }
}