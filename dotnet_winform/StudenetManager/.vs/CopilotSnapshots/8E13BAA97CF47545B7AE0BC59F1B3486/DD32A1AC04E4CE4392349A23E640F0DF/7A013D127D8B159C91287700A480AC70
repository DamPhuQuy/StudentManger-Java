namespace StudentManagement.Models;

/// <summary>
/// Represents a user (admin/staff) in the system
/// </summary>
public class User
{
    public string UserId { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string FullName { get; set; } = string.Empty;
    public string Role { get; set; } = "Staff";
    public UserRole UserRole { get; set; } = UserRole.Staff;
    public DateTime CreatedDate { get; set; }
    public bool IsActive { get; set; } = true;
    public DateTime? LastLoginDate { get; set; }

    public override string ToString()
    {
        return $"{Username} ({FullName}) - {Role}";
    }
}
