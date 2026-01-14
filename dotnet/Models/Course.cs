namespace StudentManagement.Models;

// Course entity
public class Course
{
    public string CourseId { get; set; } = string.Empty;
    public string CourseName { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int Credits { get; set; }
    public string Department { get; set; } = string.Empty;
    public string InstructorId { get; set; } = string.Empty;
    public string InstructorName { get; set; } = string.Empty;
    public int MaxStudents { get; set; } = 50;
    public string Semester { get; set; } = string.Empty;
    public int Year { get; set; }

    // Navigation properties
    public List<Enrollment> Enrollments { get; set; } = new();

    // Current enrollment count using LINQ
    public int CurrentEnrollment => Enrollments.Count;

    public bool IsFull => CurrentEnrollment >= MaxStudents;

    public void DisplayInfo()
    {
        Console.WriteLine($"\n=== Course Information ===");
        Console.WriteLine($"Course ID: {CourseId}");
        Console.WriteLine($"Course Name: {CourseName}");
        Console.WriteLine($"Description: {Description}");
        Console.WriteLine($"Credits: {Credits}");
        Console.WriteLine($"Department: {Department}");
        Console.WriteLine($"Instructor: {InstructorName} (ID: {InstructorId})");
        Console.WriteLine($"Semester: {Semester} {Year}");
        Console.WriteLine($"Enrollment: {CurrentEnrollment}/{MaxStudents}");
        Console.WriteLine($"Status: {(IsFull ? "Full" : "Available")}");
    }
}
