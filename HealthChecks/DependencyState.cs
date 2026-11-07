
namespace TrainingManagement.API.HealthChecks;

public sealed class DependencyState
{
    public bool DatabaseAvailable { get; set; } = true;
}
