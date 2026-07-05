using TmsCore.Models;

Console.WriteLine("========== LAB SESSION 1 ==========");

// Exercise 1: Null safety
string? region = null;

string? upperRegion = region?.ToUpper();
Console.WriteLine($"Region conditional: {upperRegion}");

string displayRegion = region ?? "Unassigned";
Console.WriteLine($"Region coalesced: {displayRegion}");

region ??= "Addis Ababa";
Console.WriteLine($"Region assigned: {region}");

// Exercise 2: Decimal for money
string studentName = "Abeba";
string studentId = "STU-001";
int enrollmentCount = 3;
decimal grantAmount = 1999.99m;
DateTime enrolledAt = DateTime.UtcNow;
string? campusRegion = null;

Console.WriteLine($"\nStudent: {studentName} ({studentId})");
Console.WriteLine($"Courses: {enrollmentCount}");
Console.WriteLine($"Grant: {grantAmount:F2}");
Console.WriteLine($"Enrolled: {enrolledAt:yyyy-MM-dd}");
Console.WriteLine($"Campus: {campusRegion ?? "Not assigned"}");

decimal grantPerStudent = 1999.99m;
decimal totalAllocation = grantPerStudent * 100_000m;

Console.WriteLine($"\nTotal allocated: {totalAllocation:F2}");

// Exercise 3: Immutable record
var enrollment = new EnrollmentRecord(
    "STU-001",
    "CS-401",
    DateTime.UtcNow
);

Console.WriteLine($"\nOriginal record: {enrollment}");

var corrected = enrollment with
{
    CourseCode = "CS-402"
};

Console.WriteLine($"Corrected record: {corrected}");

var duplicate = new EnrollmentRecord(
    "STU-001",
    "CS-401",
    enrollment.EnrolledAt
);

Console.WriteLine($"Same data? {enrollment == duplicate}");

// Course validation
var course = new Course
{
    Code = "CS-401",
    Title = "Advanced C#",
    Capacity = 30
};

Console.WriteLine($"\nCourse: {course.Title}");
Console.WriteLine($"Capacity: {course.Capacity}");

try
{
    course.Capacity = -5;
}
catch (ArgumentOutOfRangeException ex)
{
    Console.WriteLine($"Invalid capacity caught: {ex.Message}");
}

try
{
    course.Title = "";
}
catch (ArgumentException ex)
{
    Console.WriteLine($"Invalid title caught: {ex.Message}");
}

Console.WriteLine("\n========== SESSION 1 COMPLETED ==========");