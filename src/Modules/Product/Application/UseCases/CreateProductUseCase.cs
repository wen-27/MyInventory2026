using MyInventory2026.src.Modules.Product.Domain.Repositories;
using MyInventory2026.src.Shared.Contracts;
using ProductAggregate = MyInventory2026.src.Modules.Product.Domain.Aggregate.Product;
using ProductId = MyInventory2026.src.Modules.Product.Domain.ValueObject.ProductId;

namespace MyInventory2026.src.Modules.Product.Application.UseCases;

public sealed class CreateProductUseCase
{
    private readonly IProductRepository _productRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateProductUseCase(
        IProductRepository productRepository,
        IUnitOfWork unitOfWork)
    {
        _productRepository = productRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ProductAggregate> ExecuteAsync(
        int id,
        string codeInv,
        string nameProduct,
        int stock,
        int stockMin,
        int stockMax,
        CancellationToken cancellationToken = default)
    {
        var productId = ProductId.Create(id);

        var existing = await _productRepository.FindByIdAsync(productId, cancellationToken);
        if (existing is not null)
            throw new InvalidOperationException($"Product with id '{id}' already exists.");

        var product = ProductAggregate.Create(id, codeInv, nameProduct, stock, stockMin, stockMax);

        await _productRepository.AddAsync(product, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return product;
    }
}