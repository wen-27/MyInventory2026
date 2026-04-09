using MyInventory2026.src.Modules.Product.Domain.Aggregate;
using MyInventory2026.src.Modules.Product.Domain.Repositories;
using MyInventory2026.src.Modules.Product.Domain.ValueObject;

namespace MyInventory2026.src.Modules.Product.Application.UseCases;

public sealed class CreateProductUseCase
{
    private readonly IProductRepository _productRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateProductUseCase(IProductRepository productRepository, IUnitOfWork unitOfWork)
    {
        _productRepository = productRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Product> ExecuteAsync(
        int id,
        string nameProduct,
        string codeInv,
        int stockMin,
        int stockMax,
        int stock,
        CancellationToken cancellationToken = default)
        {
            var productId = ProductId.Create(id);
            var existing = await _productRepository.FindByIdAsync(productId, cancellationToken);

            if (existing is not null)
            {
                throw new InvalidOperationException($"Product with id '{id}' already exists.");
            }
            var product = ProductAggregate.Create(
                productId,
                nameProduct,
                codeInv,
                stockMin,
                stockMax,
                stock);

            await _productRepository.AddAsync(product, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return product;
        }
}