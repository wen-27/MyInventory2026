using MyInventory2026.src.Modules.Product.Domain.Repositories;
using MyInventory2026.src.Modules.Product.Domain.ValueObject;
using MyInventory2026.src.Shared.Contracts;

namespace MyInventory2026.src.Modules.Product.Application.UseCases;

public sealed class DeleteProductUseCase
{
    private readonly IProductRepository _productRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteProductUseCase(
        IProductRepository productRepository,
        IUnitOfWork unitOfWork)
    {
        _productRepository = productRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task ExecuteAsync(
        int id,
        CancellationToken cancellationToken = default)
    {
        var productId = ProductId.Create(id);

        var deleted = await _productRepository.DeleteByIdAsync(productId, cancellationToken);
        if (!deleted)
            throw new KeyNotFoundException($"Product with id '{id}' was not found.");

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}