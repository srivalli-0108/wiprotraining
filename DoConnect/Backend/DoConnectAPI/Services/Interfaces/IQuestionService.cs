using DoConnectAPI.DTOs;
using DoConnectAPI.Models;
using DoConnectAPI.Models.DTO;

namespace DoConnectAPI.Services.Interfaces
{
    public interface IQuestionService
    {
        Task<Question> AskQuestionAsync(QuestionDTO dto);
        Task<List<Question>> GetApprovedQuestionsAsync();
        Task<List<Question>> SearchQuestionsAsync(string query);
    }
}
