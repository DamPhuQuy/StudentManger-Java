namespace StudentManagement.Models;

/// <summary>
/// Represents an administrator in the system
/// </summary>
public class Admin : User
{
    public string AdminLevel { get; set; } = "Standard";
    public List<string> Permissions { get; set; } = new List<string>();
    
    public Admin()
    {
        Role = "Admin";
    }
}
