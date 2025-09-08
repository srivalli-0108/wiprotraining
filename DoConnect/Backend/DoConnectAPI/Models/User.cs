namespace DoConnectAPI.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string? Username { get; set; }
        public string? PasswordHash { get; set; }
        public string? Role { get; set; } // "User" or "Admin"
        public required string QuestionTitle { get; set; }

        public ICollection<Question> Questions { get; set; }
    }
}