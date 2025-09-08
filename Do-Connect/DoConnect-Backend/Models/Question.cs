using DoConnectBackend.Models;


namespace DoConnectBackend.Models;

public class Question
{
    public int QuestionId { get; set; }
    public string? QuestionTitle { get; set; }
    public string? QuestionText { get; set; }
    public string Status { get; set; } = "Pending";
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public int UserId { get; set; }
    public User? User { get; set; }

    public ICollection<Answer> Answers { get; set; } = new List<Answer>();
   
}


