using LLMOps.Gateway.Core.Prompts;

using Microsoft.EntityFrameworkCore;

namespace LLMOps.Gateway.Infrastructure.Persistence.Repositories;

public sealed class PromptTemplateRepository(AppDbContext dbContext) : IPromptTemplateRepository
{
    public Task<PromptTemplate?> GetByKeyAsync(string key, CancellationToken cancellationToken)
        => dbContext.PromptTemplates
            .Include(x => x.Versions)
            .FirstOrDefaultAsync(x => x.Key == key, cancellationToken);

    public Task<PromptTemplate?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        => dbContext.PromptTemplates
            .Include(x => x.Versions)
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

    public Task AddAsync(PromptTemplate promptTemplate, CancellationToken cancellationToken)
        => dbContext.PromptTemplates.AddAsync(promptTemplate, cancellationToken).AsTask();

    public void Update(PromptTemplate promptTemplate)
        => dbContext.PromptTemplates.Update(promptTemplate);

    public void Remove(PromptTemplate promptTemplate)
        => dbContext.PromptTemplates.Remove(promptTemplate);
}
