namespace StudentManagement.Models;

// Grade entity
public class Grade
{
    public string GradeId { get; set; } = Guid.NewGuid().ToString();
    public string StudentId { get; set; } = string.Empty;
    public string CourseId { get; set; } = string.Empty;
    public double NumericGrade { get; set; }
    public string LetterGrade => CalculateLetterGrade();
    public DateTime GradedDate { get; set; }
    public string GradedBy { get; set; } = string.Empty; // Faculty ID
    public string Comments { get; set; } = string.Empty;

    // Strategy Pattern - Grade calculation
    private string CalculateLetterGrade()
    {
        return NumericGrade switch
        {
            >= 9.0 => "A+",
            >= 8.5 => "A",
            >= 8.0 => "B+",
            >= 7.0 => "B",
            >= 6.5 => "C+",
            >= 5.5 => "C",
            >= 5.0 => "D+",
            >= 4.0 => "D",
            _ => "F"
        };
    }

    public bool IsPassing => NumericGrade >= 4.0;

    public void DisplayInfo()
    {
        Console.WriteLine($"Grade ID: {GradeId}");
        Console.WriteLine($"Student ID: {StudentId}");
        Console.WriteLine($"Course ID: {CourseId}");
        Console.WriteLine($"Numeric Grade: {NumericGrade:F2}");
        Console.WriteLine($"Letter Grade: {LetterGrade}");
        Console.WriteLine($"Status: {(IsPassing ? "Passed" : "Failed")}");
        Console.WriteLine($"Graded Date: {GradedDate:dd/MM/yyyy}");
        Console.WriteLine($"Graded By: {GradedBy}");
        if (!string.IsNullOrEmpty(Comments))
            Console.WriteLine($"Comments: {Comments}");
    }
}
