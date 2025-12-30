namespace LLMOps.Gateway.Core.Providers;

public interface ILlmProvider
{
    string Name { get; }

    Task<LlmCompletionResult> GenerateAsync(
        string prompt,
        string model,
        CancellationToken cancellationToken = default);
}
