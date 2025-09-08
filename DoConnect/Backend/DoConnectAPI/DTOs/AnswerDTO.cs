namespace DoConnectAPI.DTOs
{
    public class AnswerDTO
    {
        public int QuestionId { get; set; }
        public string? Text { get; set; }
        public int UserId { get; set; }
        public string? ImagePath { get; set; } // optional
    }
}
