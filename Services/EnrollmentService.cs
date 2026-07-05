using TmsCore.Models;

namespace TmsCore.Services;

public class EnrollmentService
{
    public EnrollmentRecord ProcessRegistration(Student? student, Course? course)
    {
        if (student is null)
            throw new ArgumentNullException(nameof(student));

        if (course is null)
            throw new ArgumentNullException(nameof(course));

        if (course.EnrolledCount >= course.Capacity)
            throw new InvalidOperationException(
                $"Course {course.Code} is already full."
            );

        Console.WriteLine($"{student.Name} is in {student.Standing}.");

        return new EnrollmentRecord(
            student.Id,
            course.Code,
            DateTime.UtcNow
        );
    }
}