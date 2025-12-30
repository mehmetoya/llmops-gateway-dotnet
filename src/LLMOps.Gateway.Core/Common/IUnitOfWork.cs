namespace LLMOps.Gateway.Core.Common;

public interface IUnitOfWork
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
