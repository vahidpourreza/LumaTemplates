using Microsoft.AspNetCore.Diagnostics.HealthChecks;

namespace LumaTemplate.Endpoints.API.Extensions.HealthCheck;
public static class HealthCheckEndpointConfiguration
{
    public static void MapHealthEnpoints(this WebApplication app)
    {


        app.MapHealthChecks("/health/ready", new HealthCheckOptions
        {
            Predicate = (check) => check.Tags.Contains("ready"),
            ResponseWriter = HealthCheckResponseWriter.WriteResponseAsync
        });

        app.MapHealthChecks("/health/live", new HealthCheckOptions
        {
            Predicate = (check) => check.Tags.Contains("live")
        });

        app.MapHealthChecks("/health", new HealthCheckOptions()); // general health check endpoint

    }
}

