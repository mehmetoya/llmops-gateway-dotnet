using LLMOps.Gateway.Core.Common;

namespace LLMOps.Gateway.Core.Prompts;

public sealed class PromptVersion : Entity
{
    public PromptVersion(Guid promptTemplateId, string version, string template, string defaultModel)
    {
        PromptTemplateId = promptTemplateId;
        Version = version;
        Template = template;
        DefaultModel = defaultModel;
    }

    private PromptVersion()
    {
    }

    public Guid PromptTemplateId { get; private set; }

    public PromptTemplate? PromptTemplate { get; private set; }

    public string Version { get; private set; } = default!;

    public string Template { get; private set; } = default!;

    public string DefaultModel { get; private set; } = default!;
}
