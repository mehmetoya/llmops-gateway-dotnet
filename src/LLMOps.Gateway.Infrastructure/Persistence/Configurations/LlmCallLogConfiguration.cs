using LLMOps.Gateway.Core.Logs;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LLMOps.Gateway.Infrastructure.Persistence.Configurations;

public sealed class LlmCallLogConfiguration : IEntityTypeConfiguration<LlmCallLog>
{
    public void Configure(EntityTypeBuilder<LlmCallLog> builder)
    {
        builder.ToTable("llm_call_logs");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Provider).HasMaxLength(50);
        builder.Property(x => x.Model).HasMaxLength(100);
        builder.Property(x => x.PromptKey).HasMaxLength(100);
        builder.Property(x => x.PromptVersion).HasMaxLength(50);

        builder.Property(x => x.ErrorCode).HasMaxLength(100);
        builder.Property(x => x.ErrorMessage).HasMaxLength(1000);

        builder.HasIndex(x => x.ExecutedAtUtc);
    }
}
