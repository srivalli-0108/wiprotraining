using DoConnectAPI.Models;

namespace DoConnectAPI.Models
{
    public class Answer
    {
        public int Id { get; set; }

        public string AnswerText { get; set; } = string.Empty;
        public int QuestionId { get; set; }
        public string UserId { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
          public string? Status { get; set; }

        // Navigation properties (optional)
        public Question? Question { get; set; }
        public User? User { get; set; }
    }
}
