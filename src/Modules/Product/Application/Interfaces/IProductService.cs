using System.Threading.Tasks;
using MyInventory2026.src.Modules.Product.Domain.Aggregate;

namespace MyInventory2026.src.Modules.Product.Application.Interfaces;

public interface IProductService
{
    Task<ProductAggregate> CreateAsync(
        int id,
        string nameProduct,
        string codeInv,
        int stockMin,
        int stockMax,
        int stock,
        CancellationToken cancellationToken = default);

    Task<Product?> GetByIdAsync(
        int id, CancellationToken cancellationToken = default);

    Task<IReadOnlyCollection<ProductAggregate>> GetAllAsync(
        CancellationToken cancellationToken = default);

    Task UpdateAsync(
        int id,
        string nameProduct,
        string codeInv,
        int stockMin,
        int stockMax,
        int stock,
        CancellationToken cancellationToken = default);

    Task DeleteAsync(
        int id, CancellationToken cancellationToken = default);

}