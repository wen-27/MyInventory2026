using Microsoft.EntityFrameworkCore;
using MyInventory2026.src.Modules.Product.Domain.Repositories;
using MyInventory2026.src.Modules.Product.Infrastructure.Entity;
using MyInventory2026.src.Shared.Context;
using ProductAggregate = MyInventory2026.src.Modules.Product.Domain.Aggregate.Product;
using ProductId = MyInventory2026.src.Modules.Product.Domain.ValueObject.ProductId;

namespace MyInventory2026.src.Modules.Product.Infrastructure.Repository;

public sealed class ProductRepository : IProductRepository
{
    private readonly AppDbContext _dbContext;

    public ProductRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddAsync(ProductAggregate product, CancellationToken cancellationToken = default)
    {
        var entity = new ProductEntity
        {
            Id = product.Id.Value,
            CodeInv = product.CodeInv.Value,
            Name = product.NameProduct.Value,
            Stock = product.Stock.Value,
            StockMin = product.StockMin.Value,
            StockMax = product.StockMax.Value
        };

        await _dbContext.Set<ProductEntity>().AddAsync(entity, cancellationToken);
    }

    public async Task<ProductAggregate?> FindByIdAsync(ProductId id, CancellationToken cancellationToken = default)
    {
        var entity = await _dbContext.Set<ProductEntity>()
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id.Value, cancellationToken);

        return entity is null
            ? null
            : ProductAggregate.Create(
                entity.Id,
                entity.CodeInv,
                entity.Name,
                entity.Stock,
                entity.StockMin,
                entity.StockMax);
    }

    public async Task<IReadOnlyCollection<ProductAggregate>> FindAllAsync(CancellationToken cancellationToken = default)
    {
        var entities = await _dbContext.Set<ProductEntity>()
            .AsNoTracking()
            .OrderBy(x => x.Name)
            .ToListAsync(cancellationToken);

        return entities
            .Select(x => ProductAggregate.Create(
                x.Id,
                x.CodeInv,
                x.Name,
                x.Stock,
                x.StockMin,
                x.StockMax))
            .ToList();
    }

    public async Task UpdateAsync(ProductAggregate product, CancellationToken cancellationToken = default)
    {
        var entity = await _dbContext.Set<ProductEntity>()
            .FirstOrDefaultAsync(x => x.Id == product.Id.Value, cancellationToken);

        if (entity is null)
            throw new KeyNotFoundException($"Product with id '{product.Id.Value}' was not found.");

        entity.CodeInv = product.CodeInv.Value;
        entity.Name = product.NameProduct.Value;
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