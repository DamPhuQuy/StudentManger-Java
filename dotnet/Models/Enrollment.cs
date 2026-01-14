namespace StudentManagement.Models;

// Enrollment - Association between Student and Course
public class Enrollment
{
    public string EnrollmentId { get; set; } = Guid.NewGuid().ToString();
    public string StudentId { get; set; } = string.Empty;
    public string CourseId { get; set; } = string.Empty;
    public DateTime EnrollmentDate { get; set; }
    public EnrollmentStatus Status { get; set; } = EnrollmentStatus.Enrolled;

    // Navigation properties
    public Student? Student { get; set; }
    public Course? Course { get; set; }
    public Grade? Grade { get; set; }

    public void DisplayInfo()
    {
        Console.WriteLine($"\nEnrollment ID: {EnrollmentId}");
        Console.WriteLine($"Student: {Student?.FullName ?? StudentId}");
        Console.WriteLine($"Course: {Course?.CourseName ?? CourseId}");
        Console.WriteLine($"Enrollment Date: {EnrollmentDate:dd/MM/yyyy}");
        Console.WriteLine($"Status: {Status}");

        if (Grade != null)
        {
            Console.WriteLine($"Grade: {Grade.NumericGrade:F2} ({Grade.LetterGrade})");
        }
        else
        {
            Console.WriteLine("Grade: Not yet graded");
        }
    }
}

public enum EnrollmentStatus
{
    Enrolled,
    Completed,
    Withdrawn,
    Failed
}
