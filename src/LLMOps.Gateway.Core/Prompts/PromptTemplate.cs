using LLMOps.Gateway.Core.Common;

namespace LLMOps.Gateway.Core.Prompts;

public sealed class PromptTemplate : Entity
{
    private readonly List<PromptVersion> versions = [];

    public PromptTemplate(string key)
    {
        Key = key;
    }

    private PromptTemplate()
    {
    }

    public string Key { get; private set; } = default!;

    public IReadOnlyCollection<PromptVersion> Versions => versions.AsReadOnly();

    public PromptVersion AddVersion(string version, string template, string defaultModel)
    {
        var promptVersion = new PromptVersion(
            promptTemplateId: Id,
            version: version,
            template: template,
            defaultModel: defaultModel);

        versions.Add(promptVersion);
        Touch();

        return promptVersion;
    }
}
