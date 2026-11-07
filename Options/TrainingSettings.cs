
namespace TrainingManagement.API.Options;

public class TrainingSettings
{
    public string ApplicationName { get; set; } = string.Empty;

    public int MaxStudents { get; set; }

    public bool AllowRegistration { get; set; }
}
