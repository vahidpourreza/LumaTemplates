namespace LumaTemplate.Endpoints.API.Extensions.HealthCheck;

public static class HealthCheckServiceCollectionExtensions
{
    public static void AddLumaBasicHealthChecks(this IServiceCollection services, IConfiguration configuration)
    {
        services
                .AddHealthChecks()
                .AddCheck<DbContextNameCommandDbContextHealthCheck>("DbContextNameCommandDbContextHealthCheck", tags: new[] { "ready" })
                .AddCheck<DbContextNameQueryDbContextHealthCheck>("DbContextNameQueryDbContextHealthCheck", tags: new[] { "ready" });
    }
}

