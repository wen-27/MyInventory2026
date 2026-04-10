using ProductAggregate = MyInventory2026.src.Modules.Product.Domain.Aggregate.Product;

namespace MyInventory2026.src.Modules.Product.Application.Interfaces;

public interface IProductService
{
    Task<ProductAggregate> CreateAsync(
        int id,
        string codeInv,
        string nameProduct,
        int stock,
        int stockMin,
        int stockMax,
        CancellationToken cancellationToken = default);

    Task<ProductAggregate?> GetByIdAsync(
        int id,
        CancellationToken cancellationToken = default);

    Task<IReadOnlyCollection<ProductAggregate>> GetAllAsync(
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