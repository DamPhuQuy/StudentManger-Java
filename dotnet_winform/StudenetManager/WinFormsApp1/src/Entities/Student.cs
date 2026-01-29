namespace StudentManagement.Models;

/// <summary>
/// Represents a student in the system
/// </summary>
public class Student
{
    public string StudentId { get; set; } = string.Empty;
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string Major { get; set; } = string.Empty;
    public DateTime EnrollmentDate { get; set; }
    public string Address { get; set; } = string.Empty;
    public DateTime DateOfBirth { get; set; }
    public string Status { get; set; } = "Active";
    public StudentStatus StudentStatus { get; set; } = StudentStatus.Active;
    public double GPA { get; set; }
    public List<Enrollment> Enrollments { get; set; } = new List<Enrollment>();

    public override string ToString()
    {
        return $"{StudentId} - {FullName} ({Major})";
    }
}
