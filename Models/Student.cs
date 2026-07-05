namespace TmsCore.Models;

public class Student
{
    public required string Id { get; init; }
    public required string Name { get; set; }
    public int Age { get; set; }
    public decimal GPA { get; set; }

    public string Standing => GPA switch
    {
        >= 3.5m => "Honors",
        >= 2.5m => "Good Standing",
        >= 2.0m => "Probation",
        _ => "Academic Warning"
    };
}