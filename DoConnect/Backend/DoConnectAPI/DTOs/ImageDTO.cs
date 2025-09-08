namespace DoConnectAPI.DTOs
{
    public class ImageDTO
    {
        public IFormFile? File { get; set; }
        public int? QuestionId { get; set; }
        public int? AnswerId { get; set; }
    }
}
