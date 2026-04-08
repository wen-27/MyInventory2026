using Microsoft.EntityFrameworkCore;
using MyInventory2026.src.Shared.IUnitOfWork;

namespace MyInventory2026.src.Shared.Context;

public sealed class UnitOfWork : IUnitOfWork
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