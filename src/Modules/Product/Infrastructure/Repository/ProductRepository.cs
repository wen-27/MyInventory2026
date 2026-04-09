using Microsoft.EntityFrameworkCore;
using MyInventory2026.src.Modules.Product.Domain;
using MyInventory2026.src.Modules.Product.Domain.Repositories;
using MyInventory2026.src.Modules.Product.Domain.ValueObject;
using MyInventory2026.src.Modules.Product.Infrastructure.Entity;
using MyInventory2026.src.Shared.Context;

namespace MyInventory2026.src.Modules.Product.Infrastructure.Repository;

public sealed class ProductRepository : IProductRepository
{
    private readonly AppDbContext _dbContext;

    public ProductRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddAsync(Product product, CancellationToken cancellationToken = default)
    {
        var entity = new ProductEntity
        {
            Id = product.Id.Value,
            CodeInv = product.CodeInv.Value,
            NameProduct = product.NameProduct.Value,
            Stock = product.Stock.Value,
            StockMin = product.StockMin.Value,
            StockMax = product.StockMax.Value
        };

        await _dbContext.Set<ProductEntity>().AddAsync(entity, cancellationToken);
    }

    public async Task<Product?> FindByIdAsync(ProductId id, CancellationToken cancellationToken = default)
    {
        var entity = await _dbContext.Set<ProductEntity>()
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id.Value, cancellationToken);

        return entity is null
            ? null
            : Product.Create(
                entity.Id,
                entity.CodeInv,
                entity.NameProduct,
                entity.Stock,
                entity.StockMin,
                entity.StockMax);
    }

    public async Task<IReadOnlyCollection<Product>> FindAllAsync(CancellationToken cancellationToken = default)
    {
        var entities = await _dbContext.Set<ProductEntity>()
            .AsNoTracking()
            .OrderBy(x => x.NameProduct)
            .ToListAsync(cancellationToken);

        return entities
            .Select(x => Product.Create(
                x.Id,
                x.CodeInv,
                x.NameProduct,
                x.Stock,
                x.StockMin,
                x.StockMax))
            .ToList();
    }

    public async Task UpdateAsync(Product product, CancellationToken cancellationToken = default)
    {
        var entity = await _dbContext.Set<ProductEntity>()
            .FirstOrDefaultAsync(x => x.Id == product.Id.Value, cancellationToken);

        if (entity is null)
            throw new KeyNotFoundException($"Product with id '{product.Id.Value}' was not found.");

        entity.CodeInv = product.CodeInv.Value;
        entity.NameProduct = product.NameProduct.Value;
        entity.Stock = product.Stock.Value;
        entity.StockMin = product.StockMin.Value;
        entity.StockMax = product.StockMax.Value;
    }

    public async Task<bool> DeleteByIdAsync(ProductId id, CancellationToken cancellationToken = default)
    {
        var entity = await _dbContext.Set<ProductEntity>()
            .FirstOrDefaultAsync(x => x.Id == id.Value, cancellationToken);

        if (entity is null)
            return false;

        _dbContext.Set<ProductEntity>().Remove(entity);
        return true;
    }
}