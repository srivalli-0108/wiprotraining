using DoConnectAPI.Models;
    public class ImageModel
    {
        public int ImageId { get; set; }
        public string? ImagePath { get; set; }

        public int? QuestionId { get; set; }
        public Question? Question { get; set; }

        public int? AnswerId { get; set; }
        public Answer? Answer { get; set; }
    }
