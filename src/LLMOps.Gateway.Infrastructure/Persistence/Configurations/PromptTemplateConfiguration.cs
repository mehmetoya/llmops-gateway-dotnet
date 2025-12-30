using LLMOps.Gateway.Core.Prompts;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LLMOps.Gateway.Infrastructure.Persistence.Configurations;

public sealed class PromptTemplateConfiguration : IEntityTypeConfiguration<PromptTemplate>
{
    public void Configure(EntityTypeBuilder<PromptTemplate> builder)
    {
        builder.ToTable("prompt_templates");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Key)
            .IsRequired()
            .HasMaxLength(100);

        builder.HasIndex(x => x.Key)
            .IsUnique();

        // Field-backed collection
        builder.Metadata
            .FindNavigation(nameof(PromptTemplate.Versions))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);

        builder.HasMany(x => x.Versions)
            .WithOne(x => x.PromptTemplate)
            .HasForeignKey(x => x.PromptTemplateId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
