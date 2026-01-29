using System.Globalization;
using StudentManagement.Models;

namespace StudentManagement.Utilities;

// CSV Helper - Utility class for CSV operations
public static class CsvHelper
{
    public static List<Student> ReadStudentsFromCsv(string filePath)
    {
        var students = new List<Student>();

        if (!File.Exists(filePath))
            throw new FileNotFoundException("CSV file not found", filePath);

        var lines = File.ReadAllLines(filePath);

        if (lines.Length == 0)
        {
            Console.WriteLine("CSV file is empty");
            return students;
        }

        // Skip header line
        for (int i = 1; i < lines.Length; i++)
        {
            try
            {
                var student = ParseStudentFromCsvLine(lines[i]);
                if (student != null)
                    students.Add(student);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error parsing line {i + 1}: {ex.Message}");
            }
        }

        return students;
    }

    private static Student? ParseStudentFromCsvLine(string line)
    {
        if (string.IsNullOrWhiteSpace(line))
            return null;

        var parts = line.Split(',');

        if (parts.Length < 7)
        {
            Console.WriteLine($"Invalid line format: {line}");
            return null;
        }

        try
        {
            return new Student
            {
                StudentId = parts[0].Trim(),
                FullName = parts[1].Trim(),
                DateOfBirth = DateTime.ParseExact(parts[2].Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture),
                Email = parts[3].Trim(),
                PhoneNumber = parts[4].Trim(),
                Major = parts[5].Trim(),
                Address = parts[6].Trim(),
                EnrollmentDate = parts.Length > 7 && !string.IsNullOrWhiteSpace(parts[7])
                    ? DateTime.ParseExact(parts[7].Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture)
                    : DateTime.Now,
                Status = parts.Length > 8 ? parts[8].Trim() : "Active",
                StudentStatus = parts.Length > 8 && Enum.TryParse<StudentStatus>(parts[8].Trim(), out var status)
                    ? status
                    : StudentStatus.Active
            };
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error parsing student data: {ex.Message}");
            return null;
        }
    }

    public static void WriteStudentsToCsv(string filePath, IEnumerable<Student> students)
    {
        using var writer = new StreamWriter(filePath);

        // Write header
        writer.WriteLine("StudentId,FullName,DateOfBirth,Email,PhoneNumber,Major,Address,EnrollmentDate,Status");

        // Write student data
        foreach (var student in students)
        {
            writer.WriteLine($"{student.StudentId},{student.FullName},{student.DateOfBirth:dd/MM/yyyy}," +
                           $"{student.Email},{student.PhoneNumber},{student.Major},{student.Address}," +
                           $"{student.EnrollmentDate:dd/MM/yyyy},{student.Status}");
        }

        Console.WriteLine($"Successfully exported {students.Count()} students to {filePath}");
    }

    public static void WriteCourseReportToCsv(string filePath, string courseId, IEnumerable<(Student student, Grade? grade)> data)
    {
        using var writer = new StreamWriter(filePath);

        // Write header
        writer.WriteLine("StudentId,FullName,Email,Grade,LetterGrade,Status");

        // Write data
        foreach (var (student, grade) in data)
        {
            var gradeValue = grade?.NumericGrade.ToString("F2") ?? "N/A";
            var letterGrade = grade?.LetterGrade ?? "N/A";
            var status = grade?.IsPassing == true ? "Passed" : (grade != null ? "Failed" : "Not Graded");

            writer.WriteLine($"{student.StudentId},{student.FullName},{student.Email}," +
                           $"{gradeValue},{letterGrade},{status}");
        }

        Console.WriteLine($"Course report exported to {filePath}");
    }
}
