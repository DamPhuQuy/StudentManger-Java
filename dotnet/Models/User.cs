namespace StudentManagement.Models;

// Base User class - Abstraction for all user types
public abstract class User
{
    public string UserId { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public UserRole Role { get; }

    protected User(UserRole role)
    {
        Role = role;
    }

    // Template method pattern - define common behavior
    public virtual void DisplayInfo()
    {
        Console.WriteLine($"User ID: {UserId}");
        Console.WriteLine($"Username: {Username}");
        Console.WriteLine($"Full Name: {FullName}");
        Console.WriteLine($"Email: {Email}");
        Console.WriteLine($"Role: {Role}");
    }
}

// Enum for user roles
public enum UserRole
{
    Admin,
    Faculty,
    Student
}

// Admin user - Liskov Substitution Principle
public class Admin : User
{
    public Admin() : base(UserRole.Admin) { }

    public override void DisplayInfo()
    {
        Console.WriteLine("\n=== Administrator Information ===");
        base.DisplayInfo();
        Console.WriteLine("Permissions: Full system access");
    }
}

// Faculty user
public class Faculty : User
{
    public string Department { get; set; } = string.Empty;
    public List<string> CoursesManaged { get; set; } = new();

    public Faculty() : base(UserRole.Faculty) { }

    public override void DisplayInfo()
    {
        Console.WriteLine("\n=== Faculty Information ===");
        base.DisplayInfo();
        Console.WriteLine($"Department: {Department}");
        Console.WriteLine($"Courses Managed: {string.Join(", ", CoursesManaged)}");
    }
}

// Student user
public class StudentUser : User
{
    public string StudentId { get; set; } = string.Empty;
    public string Major { get; set; } = string.Empty;

    public StudentUser() : base(UserRole.Student) { }

    public override void DisplayInfo()
    {
        Console.WriteLine("\n=== Student Information ===");
        base.DisplayInfo();
        Console.WriteLine($"Student ID: {StudentId}");
        Console.WriteLine($"Major: {Major}");
    }
}
