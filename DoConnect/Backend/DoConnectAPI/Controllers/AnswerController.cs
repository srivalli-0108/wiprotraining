using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using DoConnectAPI.Models;
using DoConnectAPI.Utilities;
using DoConnectAPI.Data;
using Microsoft.EntityFrameworkCore;
using DoConnectAPI.DTOs;


[ApiController]
[Route("api/[controller]")]
public class AnswerController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public AnswerController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    [Authorize(Roles = "User")]
    public async Task<IActionResult> PostAnswer([FromBody] AnswerDTO dto)
    {
        var answer = new Answer
        {
            AnswerText = dto.Text,
            QuestionId = dto.QuestionId,
            UserId = dto.UserId,
            CreatedAt = DateTime.Now,
            Status = "Pending"
        };
        _context.Answers.Add(answer);
        await _context.SaveChangesAsync();
        return Ok(answer);
    }

    [HttpGet("by-question/{questionId}")]
    public async Task<IActionResult> GetAnswers(int questionId)
    {
        var answers = await _context.Answers
            .Where(a => a.QuestionId == questionId && a.Status == "Approved")
            .Include(a => a.User)
            .ToListAsync();
        return Ok(answers);
    }
}
