
namespace TrainingManagement.API.Models;

public class Course
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public int DurationHours { get; set; }
}
