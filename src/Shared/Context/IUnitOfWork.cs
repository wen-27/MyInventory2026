using Microsoft.EntityFrameworkCore;

namespace MyInventory2026.src.Shared.Context;

public sealed class UnitOfWork : global::MyInventory2026.src.Shared.IUnitOfWork.IUnitOfWork
{
    private readonly DbContext _dbContext;

    public UnitOfWork(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return _dbContext.SaveChangesAsync(cancellationToken);
    }
}