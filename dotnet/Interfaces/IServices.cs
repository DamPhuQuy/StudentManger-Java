using StudentManagement.Models;

namespace StudentManagement.Interfaces;

// Interface Segregation Principle - Specific interfaces for specific needs
public interface IStudentService
{
    void AddStudent(Student student);
    void AddStudentsFromCsv(string filePath);
    void UpdateStudent(Student student);
    Student? GetStudent(string studentId);
    IEnumerable<Student> GetAllStudents();
    IEnumerable<Student> SearchStudents(string keyword);
    IEnumerable<Student> GetStudentsByMajor(string major);
    double GetStudentGPA(string studentId);
    IEnumerable<Enrollment> GetStudentEnrollments(string studentId);
}

public interface ICourseService
{
    void AddCourse(Course course);
    void UpdateCourse(Course course);
    Course? GetCourse(string courseId);
    IEnumerable<Course> GetAllCourses();
    IEnumerable<Course> GetCoursesByDepartment(string department);
    bool EnrollStudent(string studentId, string courseId);
    bool UnenrollStudent(string studentId, string courseId);
    IEnumerable<Student> GetEnrolledStudents(string courseId);
}

public interface IGradeService
{
    void AddGrade(Grade grade);
    void UpdateGrade(string studentId, string courseId, double numericGrade, string gradedBy, string? comments = null);
    Grade? GetGrade(string studentId, string courseId);
    IEnumerable<Grade> GetStudentGrades(string studentId);
    IEnumerable<Grade> GetCourseGrades(string courseId);
    double CalculateStudentGPA(string studentId);
}

public interface IAuthService
{
    User? Login(string username, string password);
    bool Register(User user);
    bool ChangePassword(string userId, string oldPassword, string newPassword);
    User? GetCurrentUser();
    void Logout();
}
