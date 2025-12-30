using LLMOps.Gateway.Core.Logs;
using LLMOps.Gateway.Core.Prompts;

using Microsoft.EntityFrameworkCore;

namespace LLMOps.Gateway.Infrastructure.Persistence;

public sealed class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<PromptTemplate> PromptTemplates => Set<PromptTemplate>();

    public DbSet<PromptVersion> PromptVersions => Set<PromptVersion>();

    public DbSet<LlmCallLog> LlmCallLogs => Set<LlmCallLog>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
