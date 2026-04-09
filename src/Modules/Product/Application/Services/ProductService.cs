using MyInventory2026.src.Modules.Product.Application.Interfaces;
using MyInventory2026.src.Modules.Product.Domain.Repositories;
using MyInventory2026.src.Modules.Product.Domain.ValueObject;
using MyInventory2026.src.Shared.Contracts;
using ProductAggregate = MyInventory2026.src.Modules.Product.Domain.Product.Product;

namespace MyInventory2026.src.Modules.Product.Application.Services;

public sealed class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ProductService(
        IProductRepository productRepository,
        IUnitOfWork unitOfWork)
    {
        _productRepository = productRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ProductAggregate> CreateAsync(
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

    public Task<ProductAggregate?> GetByIdAsync(
        int id,
        CancellationToken cancellationToken = default)
    {
        return _productRepository.FindByIdAsync(ProductId.Create(id), cancellationToken);
    }

    public Task<IReadOnlyCollection<ProductAggregate>> GetAllAsync(
        CancellationToken cancellationToken = default)
    {
        return _productRepository.FindAllAsync(cancellationToken);
    }

    public async Task UpdateAsync(
        int id,
        string codeInv,
        string nameProduct,
        int stock,
        int stockMin,
        int stockMax,
        CancellationToken cancellationToken = default)
    {
        var existing = await _productRepository.FindByIdAsync(ProductId.Create(id), cancellationToken);
        if (existing is null)
            throw new KeyNotFoundException($"Product with id '{id}' was not found.");

        existing.Update(codeInv, nameProduct, stock, stockMin, stockMax);

        await _productRepository.UpdateAsync(existing, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(
        int id,
        CancellationToken cancellationToken = default)
    {
        var deleted = await _productRepository.DeleteByIdAsync(ProductId.Create(id), cancellationToken);
        if (!deleted)
            throw new KeyNotFoundException($"Product with id '{id}' was not found.");

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}