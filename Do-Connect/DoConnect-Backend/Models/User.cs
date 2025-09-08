using DoConnectBackend.Models;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;

    public string Role { get; set; } = "User";  // Add Role here

    public ICollection<Answer> Answers { get; set; } = new List<Answer>();
    public ICollection<Question> Questions { get; set; } = new List<Question>();
    public string? Username { get; set; }
}
