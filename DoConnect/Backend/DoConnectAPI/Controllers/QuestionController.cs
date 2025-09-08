using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DoConnectAPI.Data;
using DoConnectAPI.Models.DTO;
using DoConnectAPI.Models;


[ApiController]
[Route("api/[controller]")]
public class QuestionController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public QuestionController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    [Authorize(Roles = "User")]
    public async Task<IActionResult> AskQuestion([FromBody] QuestionDTO dto)
    {
        var question = new Question
        {
            QuestionTitle = dto.QuestionTitle,
            QuestionText = dto.QuestionText,
            UserId = dto.UserId,
            CreatedAt = DateTime.Now,
            Status = "Pending"
        };
        _context.Questions.Add(question);
        await _context.SaveChangesAsync();
        return Ok(question);
    }

    [HttpGet("approved")]
    public async Task<IActionResult> GetApprovedQuestions()
    {
        var questions = await _context.Questions
            .Where(q => q.Status == "Approved")
            .Include(q => q.User)
            .ToListAsync();
        return Ok(questions);
    }

    [HttpGet("search")]
    public async Task<IActionResult> SearchQuestions([FromQuery] string query)
    {
        var results = await _context.Questions
            .Where(q => q.Status == "Approved" &&
                        (q.QuestionTitle.Contains(query) || q.QuestionText.Contains(query)))
            .ToListAsync();
        return Ok(results);
    }
}
