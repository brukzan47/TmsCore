using TmsCore.Models;
using TmsCore.Services;

Console.WriteLine("========== LAB SESSION 2 ==========");

var service = new EnrollmentService();

var validStudent = new Student
{
    Id = "S1",
    Name = "Abeba",
    Age = 20,
    GPA = 3.8m
};

var validCourse = new Course
{
    Code = "CS-401",
    Title = "Advanced C#",
    Capacity = 30
};

// Valid registration
var result = service.ProcessRegistration(validStudent, validCourse);

Console.WriteLine(
    $"Enrolled: {result.StudentId} in {result.CourseCode}"
);

// Null guard clause test
try
{
    service.ProcessRegistration(null, validCourse);
}
catch (ArgumentNullException ex)
{
    Console.WriteLine($"Guard caught: {ex.ParamName}");
}

// Full course test
var fullCourse = new Course
{
    Code = "CS-402",
    Title = "Full Course",
    Capacity = 1,
    EnrolledCount = 1
};

try
{
    service.ProcessRegistration(validStudent, fullCourse);
}
catch (InvalidOperationException ex)
{
    Console.WriteLine($"Business rule: {ex.Message}");
}

// LINQ student data
List<Student> students =
[
    new Student { Id = "S1", Name = "Abeba", Age = 22, GPA = 3.8m },
    new Student { Id = "S2", Name = "Kidane", Age = 21, GPA = 2.4m },
    new Student { Id = "S3", Name = "Dawit", Age = 20, GPA = 3.1m },
    new Student { Id = "S4", Name = "Sara", Age = 23, GPA = 3.9m },
    new Student { Id = "S5", Name = "Frehiwot", Age = 19, GPA = 2.0m },
    new Student { Id = "S6", Name = "Yonas", Age = 24, GPA = 3.5m },
    new Student { Id = "S7", Name = "Meron", Age = 22, GPA = 1.8m },
    new Student { Id = "S8", Name = "Tesfaye", Age = 21, GPA = 2.9m }
];

// Honors leaderboard
var leaderboard = students
    .Where(student => student.GPA >= 3.5m)
    .OrderByDescending(student => student.GPA)
    .Select(student => student.Name)
    .ToList();

Console.WriteLine($"\nFound {leaderboard.Count} Honors Students:");

foreach (var name in leaderboard)
{
    Console.WriteLine($"- {name}");
}

// Average GPA
decimal averageGpa = students.Average(student => student.GPA);

Console.WriteLine($"\nClass Average GPA: {averageGpa:F2}");

// Group students by standing
var standingGroups = students.GroupBy(student => student.Standing);

Console.WriteLine("\nStudents by Standing:");

foreach (var group in standingGroups)
{
    Console.WriteLine($"\n{group.Key}:");

    foreach (var student in group.OrderByDescending(student => student.GPA))
    {
        Console.WriteLine($"- {student.Name}: {student.GPA}");
    }
}

Console.WriteLine("\n========== SESSION 2 COMPLETED ==========");