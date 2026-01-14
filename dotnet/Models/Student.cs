namespace StudentManagement.Models;

// Student entity with encapsulation
public class Student
{
    public string StudentId { get; set; } = string.Empty;
    public string FullName { get; set; } = string.Empty;
    public DateTime DateOfBirth { get; set; }
    public string Email { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string Major { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public DateTime EnrollmentDate { get; set; }
    public StudentStatus Status { get; set; } = StudentStatus.Active;

    // Navigation properties
    public List<Enrollment> Enrollments { get; set; } = new();

    // Calculated property using LINQ
    public double GPA
    {
        get
        {
            var gradesWithGpa = Enrollments
                .Where(e => e.Grade != null && e.Grade.NumericGrade > 0)
                .Select(e => e.Grade!.NumericGrade)
                .ToList();

            return gradesWithGpa.Any() ? gradesWithGpa.Average() : 0.0;
        }
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"\n=== Student Information ===");
        Console.WriteLine($"Student ID: {StudentId}");
        Console.WriteLine($"Full Name: {FullName}");
        Console.WriteLine($"Date of Birth: {DateOfBirth:dd/MM/yyyy}");
        Console.WriteLine($"Email: {Email}");
        Console.WriteLine($"Phone: {PhoneNumber}");
        Console.WriteLine($"Major: {Major}");
        Console.WriteLine($"Address: {Address}");
        Console.WriteLine($"Enrollment Date: {EnrollmentDate:dd/MM/yyyy}");
        Console.WriteLine($"Status: {Status}");
        Console.WriteLine($"GPA: {GPA:F2}");
    }
}

public enum StudentStatus
{
    Active,
    Inactive,
    Graduated,
    Suspended
}
