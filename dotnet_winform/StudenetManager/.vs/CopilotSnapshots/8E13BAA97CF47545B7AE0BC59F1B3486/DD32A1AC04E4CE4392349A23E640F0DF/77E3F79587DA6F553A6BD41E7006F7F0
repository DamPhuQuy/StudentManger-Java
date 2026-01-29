using StudentManagement.Interfaces;
using StudentManagement.Models;
using StudentManagement.Repositories;

namespace StudentManagement.Services;

// AuthService - Singleton Pattern
public class AuthService : IAuthService
{
    private static AuthService? _instance;
    private static readonly object _lock = new();
    private readonly UserRepository _userRepository;
    private User? _currentUser;

    private AuthService(UserRepository userRepository)
    {
        _userRepository = userRepository;
        InitializeDefaultUsers();
    }

    // Singleton pattern implementation
    public static AuthService GetInstance(UserRepository userRepository)
    {
        if (_instance == null)
        {
            lock (_lock)
            {
                _instance ??= new AuthService(userRepository);
            }
        }
        return _instance;
    }

    private void InitializeDefaultUsers()
    {
        // Create default admin if not exists
        if (!_userRepository.GetAll().Any(u => u.Role == UserRole.Admin))
        {
            var admin = new Admin
            {
                UserId = "ADMIN001",
                Username = "admin",
                Password = HashPassword("admin123"),
                FullName = "System Administrator",
                Email = "admin@university.edu"
            };
            _userRepository.Add(admin);
            _userRepository.SaveChanges();
        }
    }

    public User? Login(string username, string password)
    {
        if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
        {
            Console.WriteLine("Username and password cannot be empty");
            return null;
        }

        var hashedPassword = HashPassword(password);

        // Using LINQ for authentication
        var user = _userRepository.GetAll()
            .FirstOrDefault(u => u.Username == username && u.Password == hashedPassword);

        if (user != null)
        {
            _currentUser = user;
            Console.WriteLine($"\nWelcome, {user.FullName}!");
            Console.WriteLine($"Role: {user.Role}");
            return user;
        }

        Console.WriteLine("Invalid username or password");
        return null;
    }

    public bool Register(User user)
    {
        if (user == null)
            throw new ArgumentNullException(nameof(user));

        if (string.IsNullOrWhiteSpace(user.Username) || string.IsNullOrWhiteSpace(user.Password))
        {
            Console.WriteLine("Username and password cannot be empty");
            return false;
        }

        // Check if username already exists
        if (_userRepository.GetAll().Any(u => u.Username == user.Username))
        {
            Console.WriteLine($"Username '{user.Username}' already exists");
            return false;
        }

        // Check if user ID already exists
        if (_userRepository.Exists(user.UserId))
        {
            Console.WriteLine($"User ID '{user.UserId}' already exists");
            return false;
        }

        // Hash password
        user.Password = HashPassword(user.Password);

        _userRepository.Add(user);
        _userRepository.SaveChanges();
        Console.WriteLine($"User {user.Username} registered successfully!");
        return true;
    }

    public bool ChangePassword(string userId, string oldPassword, string newPassword)
    {
        var user = _userRepository.GetById(userId);
        if (user == null)
        {
            Console.WriteLine("User not found");
            return false;
        }

        var hashedOldPassword = HashPassword(oldPassword);
        if (user.Password != hashedOldPassword)
        {
            Console.WriteLine("Old password is incorrect");
            return false;
        }

        user.Password = HashPassword(newPassword);
        _userRepository.Update(user);
        _userRepository.SaveChanges();
        Console.WriteLine("Password changed successfully!");
        return true;
    }

    public User? GetCurrentUser()
    {
        return _currentUser;
    }

    public void Logout()
    {
        if (_currentUser != null)
        {
            Console.WriteLine($"Goodbye, {_currentUser.FullName}!");
            _currentUser = null;
        }
    }

    // Simple password hashing (in production, use BCrypt or similar)
    private string HashPassword(string password)
    {
        using var sha256 = System.Security.Cryptography.SHA256.Create();
        var bytes = System.Text.Encoding.UTF8.GetBytes(password);
        var hash = sha256.ComputeHash(bytes);
        return Convert.ToBase64String(hash);
    }
}
