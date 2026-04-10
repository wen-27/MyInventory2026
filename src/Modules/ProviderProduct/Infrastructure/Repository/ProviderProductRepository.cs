using Microsoft.EntityFrameworkCore;
using MyInventory2026.src.Modules.ProviderProduct.Domain.Repositories;
using MyInventory2026.src.Modules.ProviderProduct.Infrastructure.Entity;
using MyInventory2026.src.Shared.Context;
using ProviderProductAggregate = MyInventory2026.src.Modules.ProviderProduct.Domain.Aggregate.ProviderProduct;
using ProviderProductProductId = MyInventory2026.src.Modules.ProviderProduct.Domain.ValueObject.ProviderProductProductId;
using ProviderProductProviderId = MyInventory2026.src.Modules.ProviderProduct.Domain.ValueObject.ProviderProductProviderId;

namespace MyInventory2026.src.Modules.ProviderProduct.Infrastructure.Repository;

public sealed class ProviderProductRepository : IProviderProductRepository
{
    private readonly AppDbContext _dbContext;

    public ProviderProductRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddAsync(ProviderProductAggregate providerProduct, CancellationToken cancellationToken = default)
    {
        var entity = new ProviderProductEntity
        {
            ProductId = providerProduct.Id.Value,
            ProviderId = providerProduct.ProviderId.Value
        };
        await _dbContext.Set<ProviderProductEntity>().AddAsync(entity, cancellationToken);
    }

    public async Task<ProviderProductAggregate?> FindByIdsAsync(
        ProviderProductProductId productId,
        ProviderProductProviderId providerId,
        CancellationToken cancellationToken = default)
    {
        var entity = await _dbContext.Set<ProviderProductEntity>()
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.ProductId == productId.Value && x.ProviderId == providerId.Value, cancellationToken);

        return entity is null ? null : ProviderProductAggregate.Create(entity.ProductId, entity.ProviderId);
    }

    public async Task<IReadOnlyCollection<ProviderProductAggregate>> FindAllAsync(CancellationToken cancellationToken = default)
    {
        var entities = await _dbContext.Set<ProviderProductEntity>()
            .AsNoTracking()
            .OrderBy(x => x.ProductId)
            .ToListAsync(cancellationToken);

        return entities.Select(x => ProviderProductAggregate.Create(x.ProductId, x.ProviderId)).ToList();
    }

    public async Task UpdateAsync(ProviderProductAggregate providerProduct, CancellationToken cancellationToken = default)
    {
        var entity = await _dbContext.Set<ProviderProductEntity>()
            .FirstOrDefaultAsync(x => x.ProductId == providerProduct.Id.Value && x.ProviderId == providerProduct.ProviderId.Value, cancellationToken);

        if (entity is null)
            throw new KeyNotFoundException("ProviderProduct with given IDs was not found.");

        entity.ProductId = providerProduct.Id.Value;
        entity.ProviderId = providerProduct.ProviderId.Value;
    }

    public async Task<bool> DeleteByIdsAsync(
        ProviderProductProductId productId,
        ProviderProductProviderId providerId,
        CancellationToken cancellationToken = default)
    {
        var entity = await _dbContext.Set<ProviderProductEntity>()
            .FirstOrDefaultAsync(x => x.ProductId == productId.Value && x.ProviderId == providerId.Value, cancellationToken);

        if (entity is null) return false;

        _dbContext.Set<ProviderProductEntity>().Remove(entity);
        return true;
    }
}