namespace LLMOps.Gateway.Core.Logs;

public interface ILlmCallLogRepository
{
    Task AddAsync(LlmCallLog log, CancellationToken cancellationToken);
}
