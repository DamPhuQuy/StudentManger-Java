using StudentManagement.Interfaces;
using StudentManagement.Models;
using StudentManagement.Repositories;
using StudentManagement.Utilities;

namespace StudentManagement.Services;

// StudentService with LINQ and PLINQ - Single Responsibility Principle
public class StudentService : IStudentService
{
    private readonly StudentRepository _studentRepository;
    private readonly EnrollmentRepository _enrollmentRepository;
    private readonly GradeRepository _gradeRepository;

    public StudentService(
        StudentRepository studentRepository,
        EnrollmentRepository enrollmentRepository,
        GradeRepository gradeRepository)
    {
        _studentRepository = studentRepository;
        _enrollmentRepository = enrollmentRepository;
        _gradeRepository = gradeRepository;
    }

    public void AddStudent(Student student)
    {
        if (student == null)
            throw new ArgumentNullException(nameof(student));

        if (string.IsNullOrWhiteSpace(student.StudentId))
            throw new ArgumentException("Student ID cannot be empty");

        if (_studentRepository.Exists(student.StudentId))
            throw new InvalidOperationException($"Student with ID {student.StudentId} already exists");

        _studentRepository.Add(student);
        _studentRepository.SaveChanges();
        Console.WriteLine($"Student {student.FullName} added successfully!");
    }

    public void AddStudentsFromCsv(string filePath)
    {
        if (!File.Exists(filePath))
            throw new FileNotFoundException("CSV file not found", filePath);

        var students = CsvHelper.ReadStudentsFromCsv(filePath);

        // Using PLINQ for parallel processing of large datasets
        var validStudents = students
            .AsParallel()
            .Where(s => !_studentRepository.Exists(s.StudentId))
            .ToList();

        if (validStudents.Count == 0)
        {
            Console.WriteLine("No new students to add (all already exist)");
            return;
        }

        _studentRepository.AddRange(validStudents);
        _studentRepository.SaveChanges();

        Console.WriteLine($"Successfully added {validStudents.Count} students from CSV file");
    }

    public void UpdateStudent(Student student)
    {
        if (student == null)
            throw new ArgumentNullException(nameof(student));

        if (!_studentRepository.Exists(student.StudentId))
            throw new InvalidOperationException($"Student with ID {student.StudentId} not found");

        _studentRepository.Update(student);
        _studentRepository.SaveChanges();
        Console.WriteLine($"Student {student.FullName} updated successfully!");
    }

    public Student? GetStudent(string studentId)
    {
        return _studentRepository.GetById(studentId);
    }

    public IEnumerable<Student> GetAllStudents()
    {
        // Using LINQ for ordering
        return _studentRepository.GetAll()
            .OrderBy(s => s.StudentId);
    }

    public IEnumerable<Student> SearchStudents(string keyword)
    {
        if (string.IsNullOrWhiteSpace(keyword))
            return Enumerable.Empty<Student>();

        // Using LINQ for complex queries
        return _studentRepository.GetAll()
            .Where(s =>
                s.StudentId.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                s.FullName.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                s.Email.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                s.Major.Contains(keyword, StringComparison.OrdinalIgnoreCase))
            .OrderBy(s => s.FullName);
    }

    public IEnumerable<Student> GetStudentsByMajor(string major)
    {
        // Using LINQ with AsParallel for parallel query
        return _studentRepository.GetAll()
            .AsParallel()
            .Where(s => s.Major.Equals(major, StringComparison.OrdinalIgnoreCase))
            .OrderBy(s => s.FullName);
    }

    public double GetStudentGPA(string studentId)
    {
        var student = _studentRepository.GetById(studentId);
        if (student == null)
            throw new InvalidOperationException($"Student with ID {studentId} not found");

        // Get enrollments for this student
        var enrollments = _enrollmentRepository.GetAll()
            .Where(e => e.StudentId == studentId)
            .ToList();

        // Get grades using LINQ
        var grades = _gradeRepository.GetAll()
            .Where(g => g.StudentId == studentId && g.NumericGrade > 0)
            .ToList();

        // Attach grades to enrollments
        foreach (var enrollment in enrollments)
        {
            enrollment.Grade = grades.FirstOrDefault(g => g.CourseId == enrollment.CourseId);
        }

        student.Enrollments = enrollments;
        return student.GPA;
    }

    public IEnumerable<Enrollment> GetStudentEnrollments(string studentId)
    {
        if (!_studentRepository.Exists(studentId))
            throw new InvalidOperationException($"Student with ID {studentId} not found");

        // Using LINQ with multiple joins
        var enrollments = _enrollmentRepository.GetAll()
            .Where(e => e.StudentId == studentId)
            .ToList();

        // Attach grades to enrollments
        foreach (var enrollment in enrollments)
        {
            enrollment.Grade = _gradeRepository.GetAll()
                .FirstOrDefault(g => g.StudentId == studentId && g.CourseId == enrollment.CourseId);
        }

        return enrollments.OrderByDescending(e => e.EnrollmentDate);
    }
}
