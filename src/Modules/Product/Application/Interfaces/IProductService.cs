using MyInventory2026.src.Modules.Product.Domain;

namespace MyInventory2026.src.Modules.Product.Application.Interfaces;

public interface IProductService
{
    Task<Product> CreateAsync(
        int id,
        string codeInv,
        string nameProduct,
        int stock,
        int stockMin,
        int stockMax,
        CancellationToken cancellationToken = default);

    Task<Product?> GetByIdAsync(
        int id,
        CancellationToken cancellationToken = default);

    Task<IReadOnlyCollection<Product>> GetAllAsync(
        CancellationToken cancellationToken = default);

    Task UpdateAsync(
        int id,
        string codeInv,
        string nameProduct,
        int stock,
        int stockMin,
        int stockMax,
        CancellationToken cancellationToken = default);

    Task DeleteAsync(
        int id,
        CancellationToken cancellationToken = default);
}