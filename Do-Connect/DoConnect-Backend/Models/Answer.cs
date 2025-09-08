using DoConnectBackend.Models;

namespace DoConnectBackend.Models;

public class Answer
{
    public int AnswerId { get; set; }
    public string? AnswerText { get; set; }
    public string Status { get; set; } = "Pending";
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public int QuestionId { get; set; }
    public Question? Question { get; set; }

    public int UserId { get; set; }
    public User? User { get; set; }
}
