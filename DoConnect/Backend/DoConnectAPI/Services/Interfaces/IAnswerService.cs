using DoConnectAPI.DTOs;
using DoConnectAPI.Models;

namespace DoConnectAPI.Services.Interfaces
{
    public interface IAnswerService
    {
        Task<Answer> PostAnswerAsync(AnswerDTO dto);
        Task<List<Answer>> GetApprovedAnswersAsync(int questionId);
    }
}
