namespace LLMOps.Gateway.Core.Providers;

public sealed class LlmCompletionResult
{
    public string Content { get; init; } = string.Empty;

    public int InputTokens { get; init; }

    public int OutputTokens { get; init; }

    public decimal CostUsd { get; init; }
}
