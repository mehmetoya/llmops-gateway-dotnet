using LLMOps.Gateway.Core.Prompts;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LLMOps.Gateway.Infrastructure.Persistence.Configurations;

public sealed class PromptVersionConfiguration : IEntityTypeConfiguration<PromptVersion>
{
    public void Configure(EntityTypeBuilder<PromptVersion> builder)
    {
        builder.ToTable("prompt_versions");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Version)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(x => x.Template)
            .IsRequired();

        builder.Property(x => x.DefaultModel)
            .IsRequired()
            .HasMaxLength(100);

        builder.HasIndex(x => new { x.PromptTemplateId, x.Version })
            .IsUnique();
    }
}
