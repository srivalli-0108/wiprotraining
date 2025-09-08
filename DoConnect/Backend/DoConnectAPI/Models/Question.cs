using System;
using System.ComponentModel.DataAnnotations;

namespace DoConnectAPI.Models
{
    public class Question
    {
        public int Id { get; set; }

        public string QuestionTitle { get; set; } = string.Empty;
        public string QuestionText { get; set; } = string.Empty;
        public string UserId { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public string Status { get; set; } = "Pending";

        // Navigation Property
        public User? User { get; set; }
    }
}
