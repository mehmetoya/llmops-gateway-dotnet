using LLMOps.Gateway.Core.Common;
using LLMOps.Gateway.Core.Logs;
using LLMOps.Gateway.Core.Prompts;
using LLMOps.Gateway.Infrastructure.Persistence;
using LLMOps.Gateway.Infrastructure.Persistence.Repositories;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LLMOps.Gateway.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Postgres")
            ?? throw new InvalidOperationException("Connection string 'Postgres' is missing.");

        services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString));

        // Repositories
        services.AddScoped<IPromptTemplateRepository, PromptTemplateRepository>();
        services.AddScoped<ILlmCallLogRepository, LlmCallLogRepository>();

        // Unit of Work
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}
