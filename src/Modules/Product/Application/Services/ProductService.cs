using System.Threading.Tasks;
using MyInventory2026.src.Modules.Product.Application.Interfaces;
using MyInventory2026.src.Modules.Product.Domain.Aggregate;
using MyInventory2026.src.Modules.Product.Domain.Repositories;
using MyInventory2026.src.Modules.Product.Domain.ValueObject;
using MyInventory2026.src.Shared.Contracts;  

namespace MyInventory2026.src.Modules.Product.Application.Services;

public sealed class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ProductService(IProductRepository productRepository, IUnitOfWork unitOfWork)
    {
        _productRepository = productRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task<Product> CreateAsync(
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
            var product = product.Create(
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
    public Task<Product?> GetByIdAsync(
        int id,
        CancellationToken cancellationToken = default)
    {
        var productId = ProductId.Create(id);
        return _productRepository.FindByIdAsync(productId, cancellationToken);
    }

    public Task<IReadOnlyCollection<Product>> GetAllAsync(
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
        var productId = ProductId.Create(id);

        var existing = await _productRepository.FindByIdAsync(productId, cancellationToken);
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
        var productId = ProductId.Create(id);

        var deleted = await _productRepository.DeleteByIdAsync(productId, cancellationToken);
        if (!deleted)
            throw new KeyNotFoundException($"Product with id '{id}' was not found.");

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
