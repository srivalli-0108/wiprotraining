using DoConnectAPI.DTOs;
using DoConnectAPI.Models;
using DoConnectAPI.Services.Interfaces;
using DoConnectAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace DoConnectAPI.Services
{
    public class AnswerService : IAnswerService
    {
        private readonly ApplicationDbContext _context;

        public AnswerService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Answer> PostAnswerAsync(AnswerDTO dto)
        {
            var answer = new Answer
            {
                AnswerText = dto.Text,
                QuestionId = dto.QuestionId,
                UserId = dto.UserId,
                Status = "Pending",
                CreatedAt = DateTime.UtcNow,
                ImagePath = dto.ImagePath
            };

            _context.Answers.Add(answer);
            await _context.SaveChangesAsync();

            return answer;
        }

        public async Task<List<Answer>> GetApprovedAnswersAsync(int questionId)
        {
            return await _context.Answers
                .Where(a => a.QuestionId == questionId && a.Status == "Approved")
                .Include(a => a.User)
                .ToListAsync();
        }
    }
}
