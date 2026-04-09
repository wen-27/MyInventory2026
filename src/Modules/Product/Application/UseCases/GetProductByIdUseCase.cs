using MyInventory2026.src.Modules.Product.Domain.Aggregate;
using MyInventory2026.src.Modules.Product.Domain.Repositories;
using MyInventory2026.src.Modules.Product.Domain.ValueObject;

namespace MyInventory2026.src.Modules.Product.Application.UseCases;

public sealed class GetProductByIdUseCase
{
    private readonly IProductRepository _productRepository;

    public GetProductByIdUseCase(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public Task<Product?> ExecuteAsync(
        int id,
        CancellationToken cancellationToken = default)
    {
        var productId = ProductId.Create(id);
        return _productRepository.FindByIdAsync(productId, cancellationToken);
    }
}