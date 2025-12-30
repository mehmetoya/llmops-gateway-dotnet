using LLMOps.Gateway.Core.Logs;

namespace LLMOps.Gateway.Infrastructure.Persistence.Repositories;

public sealed class LlmCallLogRepository(AppDbContext dbContext) : ILlmCallLogRepository
{
    public Task AddAsync(LlmCallLog log, CancellationToken cancellationToken)
        => dbContext.LlmCallLogs.AddAsync(log, cancellationToken).AsTask();
}
