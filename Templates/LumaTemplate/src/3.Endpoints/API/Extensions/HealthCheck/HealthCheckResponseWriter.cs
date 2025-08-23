using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace LumaTemplate.Endpoints.API.Extensions.HealthCheck;

public class HealthCheckResponseWriter
{
    public static async Task WriteResponseAsync(HttpContext context, HealthReport report)
    {
        context.Response.ContentType = "application/json";

        var result = new
        {
            status = report.Status.ToString(),
            checks = report.Entries.Select(entry => new
            {
                name = entry.Key,
                status = entry.Value.Status.ToString(),
                description = entry.Value.Description,
                exception = entry.Value.Exception?.Message // Exception details, if any
            })
        };

        if (report.Status == HealthStatus.Unhealthy)
        {
            await context.Response.WriteAsJsonAsync(result);
        }
        else
        {
            await context.Response.WriteAsJsonAsync(new { status = "Healthy" });
        }
    }
}

