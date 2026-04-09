using MyInventory2026.src.Modules.Product.Domain;
using MyInventory2026.src.Modules.Product.Domain.ValueObject;

namespace MyInventory2026.src.Modules.Product.Domain.Repositories;

public interface IProductRepository
{
    Task AddAsync(Product product, CancellationToken cancellationToken = default);
    Task<Product?> FindByIdAsync(ProductId id, CancellationToken cancellationToken = default);
    Task<IReadOnlyCollection<Product>> FindAllAsync(CancellationToken cancellationToken = default);
    Task UpdateAsync(Product product, CancellationToken cancellationToken = default);
    Task<bool> DeleteByIdAsync(ProductId id, CancellationToken cancellationToken = default);
}