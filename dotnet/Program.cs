using StudentManagement.Models;
using StudentManagement.Repositories;
using StudentManagement.Services;
using StudentManagement.Utilities;

namespace StudentManagement;

// Facade Pattern - Main application entry point
public class Program
{
    private static StudentRepository? _studentRepository;
    private static CourseRepository? _courseRepository;
    private static GradeRepository? _gradeRepository;
    private static EnrollmentRepository? _enrollmentRepository;
    private static UserRepository? _userRepository;

    private static StudentService? _studentService;
    private static CourseService? _courseService;
    private static GradeService? _gradeService;
    private static AuthService? _authService;

    public static void Main(string[] args)
    {
        InitializeSystem();
        ShowLoginScreen();
    }

    private static void InitializeSystem()
    {
        // Initialize repositories
        _studentRepository = new StudentRepository();
        _courseRepository = new CourseRepository();
        _gradeRepository = new GradeRepository();
        _enrollmentRepository = new EnrollmentRepository();
        _userRepository = new UserRepository();

        // Initialize services with dependency injection
        _studentService = new StudentService(_studentRepository, _enrollmentRepository, _gradeRepository);
        _courseService = new CourseService(_courseRepository, _studentRepository, _enrollmentRepository);
        _gradeService = new GradeService(_gradeRepository, _studentRepository, _courseRepository, _enrollmentRepository);
        _authService = AuthService.GetInstance(_userRepository);

        // Seed sample data
        SeedSampleData();
    }

    private static void SeedSampleData()
    {
        // Create sample faculty user
        var faculty = new Faculty
        {
            UserId = "FAC001",
            Username = "faculty",
            Password = "faculty123",
            FullName = "Nguyen Van Faculty",
            Email = "faculty@university.edu",
            Department = "Computer Science"
        };
        _authService?.Register(faculty);

        // Create sample student user
        var studentUser = new StudentUser
        {
            UserId = "STU001",
            Username = "student",
            Password = "student123",
            FullName = "Tran Thi Student",
            Email = "student@university.edu",
            StudentId = "SV001",
            Major = "Computer Science"
        };
        _authService?.Register(studentUser);
    }

    private static void ShowLoginScreen()
    {
        while (true)
        {
            ConsoleHelper.PrintHeader("UNIVERSITY STUDENT MANAGEMENT SYSTEM");
            Console.WriteLine("1. Login");
            Console.WriteLine("2. Exit");
            Console.WriteLine();

            var choice = ConsoleHelper.ReadInput("Enter your choice");

            switch (choice)
            {
                case "1":
                    Login();
                    break;
                case "2":
                    ConsoleHelper.PrintInfo("Thank you for using the system. Goodbye!");
                    return;
                default:
                    ConsoleHelper.PrintError("Invalid choice. Please try again.");
                    ConsoleHelper.WaitForKey();
                    break;
            }
        }
    }

    private static void Login()
    {
        ConsoleHelper.PrintHeader("LOGIN");

        var username = ConsoleHelper.ReadInput("Username");
        var password = ConsoleHelper.ReadPassword("Password");

        var user = _authService?.Login(username, password);

        if (user != null)
        {
            ConsoleHelper.WaitForKey();
            ShowMainMenu(user);
        }
        else
        {
            ConsoleHelper.WaitForKey();
        }
    }

    private static void ShowMainMenu(User user)
    {
        while (true)
        {
            ConsoleHelper.PrintHeader($"MAIN MENU - {user.FullName} ({user.Role})");

            switch (user.Role)
            {
                case UserRole.Admin:
                    ShowAdminMenu(user);
                    break;
                case UserRole.Faculty:
                    ShowFacultyMenu(user);
                    break;
                case UserRole.Student:
                    ShowStudentMenu(user);
                    break;
            }

            if (_authService?.GetCurrentUser() == null)
                break;
        }
    }

    private static void ShowAdminMenu(User user)
    {
        Console.WriteLine("=== ADMINISTRATOR MENU ===");
        Console.WriteLine("1. Student Management");
        Console.WriteLine("2. Course Management");
        Console.WriteLine("3. User Management");
        Console.WriteLine("4. Reports");
        Console.WriteLine("0. Logout");
        Console.WriteLine();

        var choice = ConsoleHelper.ReadInput("Enter your choice");

        switch (choice)
        {
            case "1":
                ShowStudentManagementMenu();
                break;
            case "2":
                ShowCourseManagementMenu();
                break;
            case "3":
                ShowUserManagementMenu();
                break;
            case "4":
                ShowReportsMenu();
                break;
            case "0":
                _authService?.Logout();
                break;
            default:
                ConsoleHelper.PrintError("Invalid choice");
                ConsoleHelper.WaitForKey();
                break;
        }
    }

    private static void ShowFacultyMenu(User user)
    {
        Console.WriteLine("=== FACULTY MENU ===");
        Console.WriteLine("1. View All Courses");
        Console.WriteLine("2. View Course Students");
        Console.WriteLine("3. Grade Management");
        Console.WriteLine("4. View My Profile");
        Console.WriteLine("0. Logout");
        Console.WriteLine();

        var choice = ConsoleHelper.ReadInput("Enter your choice");

        switch (choice)
        {
            case "1":
                ViewAllCourses();
                break;
            case "2":
                ViewCourseStudents();
                break;
            case "3":
                ShowGradeManagementMenu(user);
                break;
            case "4":
                user.DisplayInfo();
                ConsoleHelper.WaitForKey();
                break;
            case "0":
                _authService?.Logout();
                break;
            default:
                ConsoleHelper.PrintError("Invalid choice");
                ConsoleHelper.WaitForKey();
                break;
        }
    }

    private static void ShowStudentMenu(User user)
    {
        Console.WriteLine("=== STUDENT MENU ===");
        Console.WriteLine("1. View My Information");
        Console.WriteLine("2. View My Grades");
        Console.WriteLine("3. View My Courses");
        Console.WriteLine("4. Update Personal Information");
        Console.WriteLine("0. Logout");
        Console.WriteLine();

        var choice = ConsoleHelper.ReadInput("Enter your choice");

        var studentUser = user as StudentUser;
        if (studentUser == null) return;

        switch (choice)
        {
            case "1":
                ViewStudentInformation(studentUser.StudentId);
                break;
            case "2":
                ViewStudentGrades(studentUser.StudentId);
                break;
            case "3":
                ViewStudentCourses(studentUser.StudentId);
                break;
            case "4":
                UpdateStudentInformation(studentUser.StudentId);
                break;
            case "0":
                _authService?.Logout();
                break;
            default:
                ConsoleHelper.PrintError("Invalid choice");
                ConsoleHelper.WaitForKey();
                break;
        }
    }

    // Student Management
    private static void ShowStudentManagementMenu()
    {
        while (true)
        {
            ConsoleHelper.PrintHeader("STUDENT MANAGEMENT");
            Console.WriteLine("1. Add Student Manually");
            Console.WriteLine("2. Import Students from CSV");
            Console.WriteLine("3. View All Students");
            Console.WriteLine("4. Search Student");
            Console.WriteLine("5. Update Student");
            Console.WriteLine("6. View Students by Major");
            Console.WriteLine("0. Back to Main Menu");
            Console.WriteLine();

            var choice = ConsoleHelper.ReadInput("Enter your choice");

            switch (choice)
            {
                case "1":
                    AddStudentManually();
                    break;
                case "2":
                    ImportStudentsFromCsv();
                    break;
                case "3":
                    ViewAllStudents();
                    break;
                case "4":
                    SearchStudent();
                    break;
                case "5":
                    UpdateStudent();
                    break;
                case "6":
                    ViewStudentsByMajor();
                    break;
                case "0":
                    return;
                default:
                    ConsoleHelper.PrintError("Invalid choice");
                    ConsoleHelper.WaitForKey();
                    break;
            }
        }
    }

    private static void AddStudentManually()
    {
        ConsoleHelper.PrintHeader("ADD STUDENT");

        try
        {
            var student = new Student
            {
                StudentId = ConsoleHelper.ReadInput("Student ID"),
                FullName = ConsoleHelper.ReadInput("Full Name"),
                DateOfBirth = ConsoleHelper.ReadDate("Date of Birth"),
                Email = ConsoleHelper.ReadInput("Email"),
                PhoneNumber = ConsoleHelper.ReadInput("Phone Number"),
                Major = ConsoleHelper.ReadInput("Major"),
                Address = ConsoleHelper.ReadInput("Address"),
                EnrollmentDate = DateTime.Now,
                Status = StudentStatus.Active
            };

            _studentService?.AddStudent(student);
            ConsoleHelper.PrintSuccess("Student added successfully!");
        }
        catch (Exception ex)
        {
            ConsoleHelper.PrintError($"Error: {ex.Message}");
        }

        ConsoleHelper.WaitForKey();
    }

    private static void ImportStudentsFromCsv()
    {
        ConsoleHelper.PrintHeader("IMPORT STUDENTS FROM CSV");

        var filePath = ConsoleHelper.ReadInput("Enter CSV file path");

        try
        {
            _studentService?.AddStudentsFromCsv(filePath);
            ConsoleHelper.PrintSuccess("Students imported successfully!");
        }
        catch (Exception ex)
        {
            ConsoleHelper.PrintError($"Error: {ex.Message}");
        }

        ConsoleHelper.WaitForKey();
    }

    private static void ViewAllStudents()
    {
        ConsoleHelper.PrintHeader("ALL STUDENTS");

        var students = _studentService?.GetAllStudents();
        if (students == null || !students.Any())
        {
            ConsoleHelper.PrintWarning("No students found");
            ConsoleHelper.WaitForKey();
            return;
        }

        ConsoleHelper.PrintTable(students,
            ("ID", s => s.StudentId, 10),
            ("Full Name", s => s.FullName, 25),
            ("Major", s => s.Major, 20),
            ("Email", s => s.Email, 25),
            ("GPA", s => s.GPA.ToString("F2"), 6)
        );

        ConsoleHelper.WaitForKey();
    }

    private static void SearchStudent()
    {
        ConsoleHelper.PrintHeader("SEARCH STUDENT");

        var keyword = ConsoleHelper.ReadInput("Enter search keyword (ID, Name, Email, Major)");

        var students = _studentService?.SearchStudents(keyword);
        if (students == null || !students.Any())
        {
            ConsoleHelper.PrintWarning("No students found");
            ConsoleHelper.WaitForKey();
            return;
        }

        ConsoleHelper.PrintTable(students,
            ("ID", s => s.StudentId, 10),
            ("Full Name", s => s.FullName, 25),
            ("Major", s => s.Major, 20),
            ("Email", s => s.Email, 25)
        );

        ConsoleHelper.WaitForKey();
    }

    private static void UpdateStudent()
    {
        ConsoleHelper.PrintHeader("UPDATE STUDENT");

        var studentId = ConsoleHelper.ReadInput("Enter Student ID");
        var student = _studentService?.GetStudent(studentId);

        if (student == null)
        {
            ConsoleHelper.PrintError("Student not found");
            ConsoleHelper.WaitForKey();
            return;
        }

        student.DisplayInfo();
        Console.WriteLine();

        if (!ConsoleHelper.Confirm("Do you want to update this student?"))
            return;

        student.FullName = ConsoleHelper.ReadInput($"Full Name [{student.FullName}]") is string name && !string.IsNullOrWhiteSpace(name) ? name : student.FullName;
        student.Email = ConsoleHelper.ReadInput($"Email [{student.Email}]") is string email && !string.IsNullOrWhiteSpace(email) ? email : student.Email;
        student.PhoneNumber = ConsoleHelper.ReadInput($"Phone [{student.PhoneNumber}]") is string phone && !string.IsNullOrWhiteSpace(phone) ? phone : student.PhoneNumber;
        student.Address = ConsoleHelper.ReadInput($"Address [{student.Address}]") is string address && !string.IsNullOrWhiteSpace(address) ? address : student.Address;

        try
        {
            _studentService?.UpdateStudent(student);
            ConsoleHelper.PrintSuccess("Student updated successfully!");
        }
        catch (Exception ex)
        {
            ConsoleHelper.PrintError($"Error: {ex.Message}");
        }

        ConsoleHelper.WaitForKey();
    }

    private static void ViewStudentsByMajor()
    {
        ConsoleHelper.PrintHeader("VIEW STUDENTS BY MAJOR");

        var major = ConsoleHelper.ReadInput("Enter Major");

        var students = _studentService?.GetStudentsByMajor(major);
        if (students == null || !students.Any())
        {
            ConsoleHelper.PrintWarning($"No students found in {major} major");
            ConsoleHelper.WaitForKey();
            return;
        }

        ConsoleHelper.PrintTable(students,
            ("ID", s => s.StudentId, 10),
            ("Full Name", s => s.FullName, 30),
            ("Email", s => s.Email, 30),
            ("GPA", s => s.GPA.ToString("F2"), 6)
        );

        ConsoleHelper.WaitForKey();
    }

    // Course Management
    private static void ShowCourseManagementMenu()
    {
        while (true)
        {
            ConsoleHelper.PrintHeader("COURSE MANAGEMENT");
            Console.WriteLine("1. Add Course");
            Console.WriteLine("2. View All Courses");
            Console.WriteLine("3. Update Course");
            Console.WriteLine("4. Enroll Student to Course");
            Console.WriteLine("5. Unenroll Student from Course");
            Console.WriteLine("6. View Course Students");
            Console.WriteLine("0. Back to Main Menu");
            Console.WriteLine();

            var choice = ConsoleHelper.ReadInput("Enter your choice");

            switch (choice)
            {
                case "1":
                    AddCourse();
                    break;
                case "2":
                    ViewAllCourses();
                    break;
                case "3":
                    UpdateCourse();
                    break;
                case "4":
                    EnrollStudentToCourse();
                    break;
                case "5":
                    UnenrollStudentFromCourse();
                    break;
                case "6":
                    ViewCourseStudents();
                    break;
                case "0":
                    return;
                default:
                    ConsoleHelper.PrintError("Invalid choice");
                    ConsoleHelper.WaitForKey();
                    break;
            }
        }
    }

    private static void AddCourse()
    {
        ConsoleHelper.PrintHeader("ADD COURSE");

        try
        {
            var course = new Course
            {
                CourseId = ConsoleHelper.ReadInput("Course ID"),
                CourseName = ConsoleHelper.ReadInput("Course Name"),
                Description = ConsoleHelper.ReadInput("Description"),
                Credits = ConsoleHelper.ReadInt("Credits", 1, 10),
                Department = ConsoleHelper.ReadInput("Department"),
                InstructorId = ConsoleHelper.ReadInput("Instructor ID"),
                InstructorName = ConsoleHelper.ReadInput("Instructor Name"),
                MaxStudents = ConsoleHelper.ReadInt("Max Students", 1, 200),
                Semester = ConsoleHelper.ReadInput("Semester (e.g., Fall, Spring)"),
                Year = ConsoleHelper.ReadInt("Year", 2020, 2030)
            };

            _courseService?.AddCourse(course);
            ConsoleHelper.PrintSuccess("Course added successfully!");
        }
        catch (Exception ex)
        {
            ConsoleHelper.PrintError($"Error: {ex.Message}");
        }

        ConsoleHelper.WaitForKey();
    }

    private static void ViewAllCourses()
    {
        ConsoleHelper.PrintHeader("ALL COURSES");

        var courses = _courseService?.GetAllCourses();
        if (courses == null || !courses.Any())
        {
            ConsoleHelper.PrintWarning("No courses found");
            ConsoleHelper.WaitForKey();
            return;
        }

        ConsoleHelper.PrintTable(courses,
            ("ID", c => c.CourseId, 10),
            ("Name", c => c.CourseName, 30),
            ("Department", c => c.Department, 20),
            ("Credits", c => c.Credits.ToString(), 7),
            ("Semester", c => $"{c.Semester} {c.Year}", 15)
        );

        ConsoleHelper.WaitForKey();
    }

    private static void UpdateCourse()
    {
        ConsoleHelper.PrintHeader("UPDATE COURSE");

        var courseId = ConsoleHelper.ReadInput("Enter Course ID");
        var course = _courseService?.GetCourse(courseId);

        if (course == null)
        {
            ConsoleHelper.PrintError("Course not found");
            ConsoleHelper.WaitForKey();
            return;
        }

        course.DisplayInfo();
        Console.WriteLine();

        if (!ConsoleHelper.Confirm("Do you want to update this course?"))
            return;

        course.CourseName = ConsoleHelper.ReadInput($"Course Name [{course.CourseName}]") is string name && !string.IsNullOrWhiteSpace(name) ? name : course.CourseName;
        course.Description = ConsoleHelper.ReadInput($"Description [{course.Description}]") is string desc && !string.IsNullOrWhiteSpace(desc) ? desc : course.Description;
        course.InstructorName = ConsoleHelper.ReadInput($"Instructor [{course.InstructorName}]") is string instructor && !string.IsNullOrWhiteSpace(instructor) ? instructor : course.InstructorName;

        try
        {
            _courseService?.UpdateCourse(course);
            ConsoleHelper.PrintSuccess("Course updated successfully!");
        }
        catch (Exception ex)
        {
            ConsoleHelper.PrintError($"Error: {ex.Message}");
        }

        ConsoleHelper.WaitForKey();
    }

    private static void EnrollStudentToCourse()
    {
        ConsoleHelper.PrintHeader("ENROLL STUDENT TO COURSE");

        var studentId = ConsoleHelper.ReadInput("Enter Student ID");
        var courseId = ConsoleHelper.ReadInput("Enter Course ID");

        try
        {
            var result = _courseService?.EnrollStudent(studentId, courseId);
            if (result == true)
                ConsoleHelper.PrintSuccess("Student enrolled successfully!");
            else
                ConsoleHelper.PrintError("Failed to enroll student");
        }
        catch (Exception ex)
        {
            ConsoleHelper.PrintError($"Error: {ex.Message}");
        }

        ConsoleHelper.WaitForKey();
    }

    private static void UnenrollStudentFromCourse()
    {
        ConsoleHelper.PrintHeader("UNENROLL STUDENT FROM COURSE");

        var studentId = ConsoleHelper.ReadInput("Enter Student ID");
        var courseId = ConsoleHelper.ReadInput("Enter Course ID");

        try
        {
            var result = _courseService?.UnenrollStudent(studentId, courseId);
            if (result == true)
                ConsoleHelper.PrintSuccess("Student unenrolled successfully!");
            else
                ConsoleHelper.PrintError("Failed to unenroll student");
        }
        catch (Exception ex)
        {
            ConsoleHelper.PrintError($"Error: {ex.Message}");
        }

        ConsoleHelper.WaitForKey();
    }

    private static void ViewCourseStudents()
    {
        ConsoleHelper.PrintHeader("VIEW COURSE STUDENTS");

        var courseId = ConsoleHelper.ReadInput("Enter Course ID");

        try
        {
            var course = _courseService?.GetCourse(courseId);
            if (course == null)
            {
                ConsoleHelper.PrintError("Course not found");
                ConsoleHelper.WaitForKey();
                return;
            }

            course.DisplayInfo();
            Console.WriteLine();

            var students = _courseService?.GetEnrolledStudents(courseId);
            if (students == null || !students.Any())
            {
                ConsoleHelper.PrintWarning("No students enrolled in this course");
                ConsoleHelper.WaitForKey();
                return;
            }

            ConsoleHelper.PrintSubHeader("Enrolled Students:");
            ConsoleHelper.PrintTable(students,
                ("ID", s => s.StudentId, 10),
                ("Full Name", s => s.FullName, 30),
                ("Major", s => s.Major, 20),
                ("Email", s => s.Email, 25)
            );
        }
        catch (Exception ex)
        {
            ConsoleHelper.PrintError($"Error: {ex.Message}");
        }

        ConsoleHelper.WaitForKey();
    }

    // Grade Management
    private static void ShowGradeManagementMenu(User user)
    {
        while (true)
        {
            ConsoleHelper.PrintHeader("GRADE MANAGEMENT");
            Console.WriteLine("1. Add/Update Grade");
            Console.WriteLine("2. View Student Grades");
            Console.WriteLine("3. View Course Grades");
            Console.WriteLine("0. Back to Main Menu");
            Console.WriteLine();

            var choice = ConsoleHelper.ReadInput("Enter your choice");

            switch (choice)
            {
                case "1":
                    AddOrUpdateGrade(user);
                    break;
                case "2":
                    ViewStudentGradesMenu();
                    break;
                case "3":
                    ViewCourseGradesMenu();
                    break;
                case "0":
                    return;
                default:
                    ConsoleHelper.PrintError("Invalid choice");
                    ConsoleHelper.WaitForKey();
                    break;
            }
        }
    }

    private static void AddOrUpdateGrade(User user)
    {
        ConsoleHelper.PrintHeader("ADD/UPDATE GRADE");

        var studentId = ConsoleHelper.ReadInput("Enter Student ID");
        var courseId = ConsoleHelper.ReadInput("Enter Course ID");
        var numericGrade = ConsoleHelper.ReadDouble("Enter Grade (0-10)", 0, 10);
        var comments = ConsoleHelper.ReadInput("Enter Comments (optional)");

        try
        {
            _gradeService?.UpdateGrade(studentId, courseId, numericGrade, user.UserId, comments);
            ConsoleHelper.PrintSuccess("Grade saved successfully!");
        }
        catch (Exception ex)
        {
            ConsoleHelper.PrintError($"Error: {ex.Message}");
        }

        ConsoleHelper.WaitForKey();
    }

    private static void ViewStudentGradesMenu()
    {
        ConsoleHelper.PrintHeader("VIEW STUDENT GRADES");

        var studentId = ConsoleHelper.ReadInput("Enter Student ID");
        ViewStudentGrades(studentId);
    }

    private static void ViewStudentGrades(string studentId)
    {
        try
        {
            var student = _studentService?.GetStudent(studentId);
            if (student == null)
            {
                ConsoleHelper.PrintError("Student not found");
                ConsoleHelper.WaitForKey();
                return;
            }

            student.DisplayInfo();
            Console.WriteLine();

            var grades = _gradeService?.GetStudentGrades(studentId);
            if (grades == null || !grades.Any())
            {
                ConsoleHelper.PrintWarning("No grades found for this student");
                ConsoleHelper.WaitForKey();
                return;
            }

            ConsoleHelper.PrintSubHeader("Student Grades:");
            ConsoleHelper.PrintTable(grades,
                ("Course ID", g => g.CourseId, 10),
                ("Numeric", g => g.NumericGrade.ToString("F2"), 8),
                ("Letter", g => g.LetterGrade, 6),
                ("Status", g => g.IsPassing ? "Passed" : "Failed", 8),
                ("Date", g => g.GradedDate.ToString("dd/MM/yyyy"), 12)
            );

            var gpa = _gradeService?.CalculateStudentGPA(studentId);
            ConsoleHelper.PrintInfo($"GPA: {gpa:F2}");
        }
        catch (Exception ex)
        {
            ConsoleHelper.PrintError($"Error: {ex.Message}");
        }

        ConsoleHelper.WaitForKey();
    }

    private static void ViewCourseGradesMenu()
    {
        ConsoleHelper.PrintHeader("VIEW COURSE GRADES");

        var courseId = ConsoleHelper.ReadInput("Enter Course ID");

        try
        {
            var course = _courseService?.GetCourse(courseId);
            if (course == null)
            {
                ConsoleHelper.PrintError("Course not found");
                ConsoleHelper.WaitForKey();
                return;
            }

            course.DisplayInfo();
            Console.WriteLine();

            var grades = _gradeService?.GetCourseGrades(courseId);
            if (grades == null || !grades.Any())
            {
                ConsoleHelper.PrintWarning("No grades found for this course");
                ConsoleHelper.WaitForKey();
                return;
            }

            ConsoleHelper.PrintSubHeader("Course Grades:");
            ConsoleHelper.PrintTable(grades,
                ("Student ID", g => g.StudentId, 12),
                ("Numeric", g => g.NumericGrade.ToString("F2"), 8),
                ("Letter", g => g.LetterGrade, 6),
                ("Status", g => g.IsPassing ? "Passed" : "Failed", 8),
                ("Date", g => g.GradedDate.ToString("dd/MM/yyyy"), 12)
            );

            var average = grades.Average(g => g.NumericGrade);
            ConsoleHelper.PrintInfo($"Course Average: {average:F2}");
        }
        catch (Exception ex)
        {
            ConsoleHelper.PrintError($"Error: {ex.Message}");
        }

        ConsoleHelper.WaitForKey();
    }

    // Student Views
    private static void ViewStudentInformation(string studentId)
    {
        ConsoleHelper.PrintHeader("MY INFORMATION");

        try
        {
            var student = _studentService?.GetStudent(studentId);
            if (student == null)
            {
                ConsoleHelper.PrintError("Student not found");
                ConsoleHelper.WaitForKey();
                return;
            }

            student.DisplayInfo();
        }
        catch (Exception ex)
        {
            ConsoleHelper.PrintError($"Error: {ex.Message}");
        }

        ConsoleHelper.WaitForKey();
    }

    private static void ViewStudentCourses(string studentId)
    {
        ConsoleHelper.PrintHeader("MY COURSES");

        try
        {
            var enrollments = _studentService?.GetStudentEnrollments(studentId);
            if (enrollments == null || !enrollments.Any())
            {
                ConsoleHelper.PrintWarning("You are not enrolled in any courses");
                ConsoleHelper.WaitForKey();
                return;
            }

            foreach (var enrollment in enrollments)
            {
                enrollment.DisplayInfo();
            }
        }
        catch (Exception ex)
        {
            ConsoleHelper.PrintError($"Error: {ex.Message}");
        }

        ConsoleHelper.WaitForKey();
    }

    private static void UpdateStudentInformation(string studentId)
    {
        ConsoleHelper.PrintHeader("UPDATE MY INFORMATION");

        try
        {
            var student = _studentService?.GetStudent(studentId);
            if (student == null)
            {
                ConsoleHelper.PrintError("Student not found");
                ConsoleHelper.WaitForKey();
                return;
            }

            student.DisplayInfo();
            Console.WriteLine();

            if (!ConsoleHelper.Confirm("Do you want to update your information?"))
                return;

            student.Email = ConsoleHelper.ReadInput($"Email [{student.Email}]") is string email && !string.IsNullOrWhiteSpace(email) ? email : student.Email;
            student.PhoneNumber = ConsoleHelper.ReadInput($"Phone [{student.PhoneNumber}]") is string phone && !string.IsNullOrWhiteSpace(phone) ? phone : student.PhoneNumber;
            student.Address = ConsoleHelper.ReadInput($"Address [{student.Address}]") is string address && !string.IsNullOrWhiteSpace(address) ? address : student.Address;

            _studentService?.UpdateStudent(student);
            ConsoleHelper.PrintSuccess("Information updated successfully!");
        }
        catch (Exception ex)
        {
            ConsoleHelper.PrintError($"Error: {ex.Message}");
        }

        ConsoleHelper.WaitForKey();
    }

    // User Management
    private static void ShowUserManagementMenu()
    {
        while (true)
        {
            ConsoleHelper.PrintHeader("USER MANAGEMENT");
            Console.WriteLine("1. Register New User");
            Console.WriteLine("2. View All Users");
            Console.WriteLine("0. Back to Main Menu");
            Console.WriteLine();

            var choice = ConsoleHelper.ReadInput("Enter your choice");

            switch (choice)
            {
                case "1":
                    RegisterNewUser();
                    break;
                case "2":
                    ViewAllUsers();
                    break;
                case "0":
                    return;
                default:
                    ConsoleHelper.PrintError("Invalid choice");
                    ConsoleHelper.WaitForKey();
                    break;
            }
        }
    }

    private static void RegisterNewUser()
    {
        ConsoleHelper.PrintHeader("REGISTER NEW USER");

        Console.WriteLine("Select User Role:");
        Console.WriteLine("1. Admin");
        Console.WriteLine("2. Faculty");
        Console.WriteLine("3. Student");

        var roleChoice = ConsoleHelper.ReadInput("Enter choice");

        User? newUser = roleChoice switch
        {
            "1" => new Admin(),
            "2" => new Faculty(),
            "3" => new StudentUser(),
            _ => null
        };

        if (newUser == null)
        {
            ConsoleHelper.PrintError("Invalid role selection");
            ConsoleHelper.WaitForKey();
            return;
        }

        try
        {
            newUser.UserId = ConsoleHelper.ReadInput("User ID");
            newUser.Username = ConsoleHelper.ReadInput("Username");
            newUser.Password = ConsoleHelper.ReadPassword("Password");
            newUser.FullName = ConsoleHelper.ReadInput("Full Name");
            newUser.Email = ConsoleHelper.ReadInput("Email");

            if (newUser is Faculty faculty)
            {
                faculty.Department = ConsoleHelper.ReadInput("Department");
            }
            else if (newUser is StudentUser studentUser)
            {
                studentUser.StudentId = ConsoleHelper.ReadInput("Student ID");
                studentUser.Major = ConsoleHelper.ReadInput("Major");
            }

            _authService?.Register(newUser);
            ConsoleHelper.PrintSuccess("User registered successfully!");
        }
        catch (Exception ex)
        {
            ConsoleHelper.PrintError($"Error: {ex.Message}");
        }

        ConsoleHelper.WaitForKey();
    }

    private static void ViewAllUsers()
    {
        ConsoleHelper.PrintHeader("ALL USERS");

        var users = _userRepository?.GetAll();
        if (users == null || !users.Any())
        {
            ConsoleHelper.PrintWarning("No users found");
            ConsoleHelper.WaitForKey();
            return;
        }

        ConsoleHelper.PrintTable(users,
            ("User ID", u => u.UserId, 12),
            ("Username", u => u.Username, 15),
            ("Full Name", u => u.FullName, 25),
            ("Role", u => u.Role.ToString(), 10),
            ("Email", u => u.Email, 25)
        );

        ConsoleHelper.WaitForKey();
    }

    // Reports
    private static void ShowReportsMenu()
    {
        while (true)
        {
            ConsoleHelper.PrintHeader("REPORTS");
            Console.WriteLine("1. Student Statistics");
            Console.WriteLine("2. Course Statistics");
            Console.WriteLine("3. Export Course Grades to CSV");
            Console.WriteLine("0. Back to Main Menu");
            Console.WriteLine();

            var choice = ConsoleHelper.ReadInput("Enter your choice");

            switch (choice)
            {
                case "1":
                    ShowStudentStatistics();
                    break;
                case "2":
                    ShowCourseStatistics();
                    break;
                case "3":
                    ExportCourseGradesToCsv();
                    break;
                case "0":
                    return;
                default:
                    ConsoleHelper.PrintError("Invalid choice");
                    ConsoleHelper.WaitForKey();
                    break;
            }
        }
    }

    private static void ShowStudentStatistics()
    {
        ConsoleHelper.PrintHeader("STUDENT STATISTICS");

        var students = _studentService?.GetAllStudents()?.ToList();
        if (students == null || !students.Any())
        {
            ConsoleHelper.PrintWarning("No students found");
            ConsoleHelper.WaitForKey();
            return;
        }

        // Using LINQ for statistics
        var totalStudents = students.Count;
        var activeStudents = students.Count(s => s.Status == StudentStatus.Active);
        var graduatedStudents = students.Count(s => s.Status == StudentStatus.Graduated);

        var studentsByMajor = students
            .GroupBy(s => s.Major)
            .Select(g => new { Major = g.Key, Count = g.Count() })
            .OrderByDescending(x => x.Count);

        Console.WriteLine($"Total Students: {totalStudents}");
        Console.WriteLine($"Active Students: {activeStudents}");
        Console.WriteLine($"Graduated Students: {graduatedStudents}");
        Console.WriteLine();

        ConsoleHelper.PrintSubHeader("Students by Major:");
        foreach (var item in studentsByMajor)
        {
            Console.WriteLine($"{item.Major}: {item.Count} students");
        }

        ConsoleHelper.WaitForKey();
    }

    private static void ShowCourseStatistics()
    {
        ConsoleHelper.PrintHeader("COURSE STATISTICS");

        var courses = _courseService?.GetAllCourses()?.ToList();
        if (courses == null || !courses.Any())
        {
            ConsoleHelper.PrintWarning("No courses found");
            ConsoleHelper.WaitForKey();
            return;
        }

        // Using PLINQ for parallel statistics
        var totalCourses = courses.Count;
        var coursesByDepartment = courses
            .AsParallel()
            .GroupBy(c => c.Department)
            .Select(g => new { Department = g.Key, Count = g.Count() })
            .OrderByDescending(x => x.Count);

        Console.WriteLine($"Total Courses: {totalCourses}");
        Console.WriteLine();

        ConsoleHelper.PrintSubHeader("Courses by Department:");
        foreach (var item in coursesByDepartment)
        {
            Console.WriteLine($"{item.Department}: {item.Count} courses");
        }

        ConsoleHelper.WaitForKey();
    }

    private static void ExportCourseGradesToCsv()
    {
        ConsoleHelper.PrintHeader("EXPORT COURSE GRADES");

        var courseId = ConsoleHelper.ReadInput("Enter Course ID");
        var filePath = ConsoleHelper.ReadInput("Enter output file path (e.g., grades.csv)");

        try
        {
            var students = _courseService?.GetEnrolledStudents(courseId)?.ToList();
            if (students == null || !students.Any())
            {
                ConsoleHelper.PrintWarning("No students found in this course");
                ConsoleHelper.WaitForKey();
                return;
            }

            var data = students.Select(s =>
            {
                var grade = _gradeService?.GetGrade(s.StudentId, courseId);
                return (student: s, grade: grade);
            });

            CsvHelper.WriteCourseReportToCsv(filePath, courseId, data);
            ConsoleHelper.PrintSuccess("Grades exported successfully!");
        }
        catch (Exception ex)
        {
            ConsoleHelper.PrintError($"Error: {ex.Message}");
        }

        ConsoleHelper.WaitForKey();
    }
}
