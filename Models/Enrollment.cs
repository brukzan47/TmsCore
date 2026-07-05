namespace TmsCore.Models;

public record EnrollmentRecord(
    string StudentId,
    string CourseCode,
    DateTime EnrolledAt
);