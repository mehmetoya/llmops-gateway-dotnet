namespace LLMOps.Gateway.Core.Prompts;

public interface IPromptTemplateRepository
{
    Task<PromptTemplate?> GetByKeyAsync(string key, CancellationToken cancellationToken);

    Task<PromptTemplate?> GetByIdAsync(Guid id, CancellationToken cancellationToken);

    Task AddAsync(PromptTemplate promptTemplate, CancellationToken cancellationToken);

    void Update(PromptTemplate promptTemplate);

    void Remove(PromptTemplate promptTemplate);
}
