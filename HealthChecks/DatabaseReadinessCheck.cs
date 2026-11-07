
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace TrainingManagement.API.HealthChecks;

public sealed class DatabaseReadinessCheck : IHealthCheck
{
    private readonly DependencyState _state;

    public DatabaseReadinessCheck(DependencyState state)
    {
        _state = state;
    }

    public Task<HealthCheckResult> CheckHealthAsync(
        HealthCheckContext context,
        CancellationToken cancellationToken = default)
    {
        if (_state.DatabaseAvailable)
        {
            return Task.FromResult(
                HealthCheckResult.Healthy(
                    "Database is available."));
        }

        return Task.FromResult(
            HealthCheckResult.Unhealthy(
                "Database is unavailable."));
    }
}
