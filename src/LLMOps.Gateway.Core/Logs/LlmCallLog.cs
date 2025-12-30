using LLMOps.Gateway.Core.Common;

namespace LLMOps.Gateway.Core.Logs;

/// <summary>
/// Stores metadata for a single LLM call.
/// Used for observability, cost tracking and evaluation.
/// </summary>
public sealed class LlmCallLog : Entity
{
    private LlmCallLog()
    {
    }

    public string PromptKey { get; private set; } = default!;

    public string PromptVersion { get; private set; } = default!;

    public string Provider { get; private set; } = default!;

    public string Model { get; private set; } = default!;

    public bool Success { get; private set; }

    public int? InputTokens { get; private set; }

    public int? OutputTokens { get; private set; }

    public decimal? CostUsd { get; private set; }

    public long LatencyMs { get; private set; }

    public string? ErrorCode { get; private set; }

    public string? ErrorMessage { get; private set; }

    public DateTime ExecutedAtUtc { get; private set; } = DateTime.UtcNow;

    public static LlmCallLog SuccessCall(
        string promptKey,
        string promptVersion,
        string provider,
        string model,
        int inputTokens,
        int outputTokens,
        decimal costUsd,
        long latencyMs)
    {
        return new LlmCallLog
        {
            PromptKey = promptKey,
            PromptVersion = promptVersion,
            Provider = provider,
            Model = model,
            InputTokens = inputTokens,
            OutputTokens = outputTokens,
            CostUsd = costUsd,
            LatencyMs = latencyMs,
            Success = true,
        };
    }

    public static LlmCallLog FailedCall(
        string promptKey,
        string promptVersion,
        string provider,
        string model,
        string errorCode,
        string errorMessage,
        long latencyMs)
    {
        return new LlmCallLog
        {
            PromptKey = promptKey,
            PromptVersion = promptVersion,
            Provider = provider,
            Model = model,
            ErrorCode = errorCode,
            ErrorMessage = errorMessage,
            LatencyMs = latencyMs,
            Success = false,
        };
    }
}
