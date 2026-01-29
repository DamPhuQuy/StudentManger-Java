namespace StudentManagement.Models;

/// <summary>
/// Represents a course in the system
/// </summary>
public class Course
{
    public string CourseId { get; set; } = string.Empty;
    public string CourseName { get; set; } = string.Empty;
    public string Department { get; set; } = string.Empty;
    public int Credits { get; set; }
    public string Instructor { get; set; } = string.Empty;
    public string Semester { get; set; } = string.Empty;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int MaxCapacity { get; set; }
    public string Description { get; set; } = string.Empty;
    public int MaxStudents { get; set; }
    public List<Enrollment> Enrollments { get; set; } = new List<Enrollment>();

    public override string ToString()
    {
        return $"{CourseId} - {CourseName} ({Department})";
    }
}
