using Microsoft.AspNetCore.Http.Json;
using LLMOps.Gateway.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<JsonOptions>(options =>
{
    options.SerializerOptions.PropertyNamingPolicy = null;
});
builder.Services.AddInfrastructure(builder.Configuration);
var app = builder.Build();

app.MapGet("/health", () => Results.Ok(new { status = "ok" }))
   .WithName("HealthCheck")
   .WithTags("System");

app.Run();
