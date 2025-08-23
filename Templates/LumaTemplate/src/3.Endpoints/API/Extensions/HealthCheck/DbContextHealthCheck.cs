using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using LumaTemplate.Infra.Data.Sql.Commands.Common;
using LumaTemplate.Infra.Data.Sql.Queries.Common;

namespace LumaTemplate.Endpoints.API.Extensions.HealthCheck;

public class DbContextNameCommandDbContextHealthCheck : IHealthCheck
{
    private readonly DbContextNameCommandDbContext _dbContext;

    public DbContextNameCommandDbContextHealthCheck(DbContextNameCommandDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
    {
        try
        {
            // Execute a simple query to check database connectivity
            await _dbContext.Database.ExecuteSqlRawAsync("SELECT 1;", cancellationToken);
            return HealthCheckResult.Healthy("CommandDbContext is connected.");
        }
        catch (Exception ex)
        {
            return HealthCheckResult.Unhealthy("CommandDbContext is not connected", ex);
        }
    }
}
public class DbContextNameQueryDbContextHealthCheck : IHealthCheck
{
    private readonly DbContextNameQueryDbContext _dbContext;

    public DbContextNameQueryDbContextHealthCheck(DbContextNameQueryDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
    {
        try
        {
            // Execute a simple query to check database connectivity
            await _dbContext.Database.ExecuteSqlRawAsync("SELECT 1;", cancellationToken);
            return HealthCheckResult.Healthy("QueryDbContext is connected.");
        }
        catch (Exception ex)
        {
            return HealthCheckResult.Unhealthy("QueryDbContext is not connected", ex);
        }
    }
}

