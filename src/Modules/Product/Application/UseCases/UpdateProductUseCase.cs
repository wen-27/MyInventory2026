using MyInventory2026.src.Modules.Product.Domain.Repositories;
using MyInventory2026.src.Modules.Product.Domain.ValueObject;
using MyInventory2026.src.Shared.Contracts;

namespace MyInventory2026.src.Modules.Product.Application.UseCases;

public sealed class UpdateProductUseCase
{
    private readonly IProductRepository _productRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateProductUseCase(
        IProductRepository productRepository,
        IUnitOfWork unitOfWork)
    {
        _productRepository = productRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task ExecuteAsync(
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
        if (existing is null)
            throw new KeyNotFoundException($"Product with id '{id}' was not found.");

        existing.Update(codeInv, nameProduct, stock, stockMin, stockMax);

        await _productRepository.UpdateAsync(existing, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}