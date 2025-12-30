using LLMOps.Gateway.Core.Common;

namespace LLMOps.Gateway.Infrastructure.Persistence;

public sealed class UnitOfWork(AppDbContext dbContext) : IUnitOfWork
{
    public Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        => dbContext.SaveChangesAsync(cancellationToken);
}
