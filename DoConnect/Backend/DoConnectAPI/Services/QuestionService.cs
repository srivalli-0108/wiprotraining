using DoConnectAPI.DTOs;
using DoConnectAPI.Models;
using DoConnectAPI.Services.Interfaces;
using DoConnectAPI.Data;
using Microsoft.EntityFrameworkCore;
using DoConnectAPI.Models.DTO;

namespace DoConnectAPI.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly ApplicationDbContext _context;

        public QuestionService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Question> AskQuestionAsync(QuestionDTO dto)
        {
            var question = new Question
            {
                QuestionTitle = dto.QuestionTitle,
                QuestionText = dto.QuestionText,
                UserId = dto.UserId,
                CreatedAt = DateTime.UtcNow,
                Status = "Pending",
                ImagePath = dto.ImagePath
            };

            _context.Questions.Add(question);
            await _context.SaveChangesAsync();

            return question;
        }

        public async Task<List<Question>> GetApprovedQuestionsAsync()
        {
            return await _context.Questions
                .Include(q => q.User)
                .Where(q => q.Status == "Approved")
                .ToListAsync();
        }

        public async Task<List<Question>> SearchQuestionsAsync(string query)
        {
            return await _context.Questions
                .Where(q => q.Status == "Approved" &&
                    (q.QuestionTitle.Contains(query) || q.QuestionText.Contains(query)))
                .ToListAsync();
        }
    }
}
