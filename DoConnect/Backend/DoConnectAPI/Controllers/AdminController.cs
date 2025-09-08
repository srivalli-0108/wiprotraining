using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DoConnectAPI.Data;


[ApiController]
[Route("api/[controller]")]
[Authorize(Roles = "Admin")]
public class AdminController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public AdminController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet("pending-questions")]
    public async Task<IActionResult> GetPendingQuestions()
    {
        var questions = await _context.Questions
            .Where(q => q.Status == "Pending")
            .Include(q => q.User)
            .ToListAsync();
        return Ok(questions);
    }

    [HttpPost("approve-question/{id}")]
    public async Task<IActionResult> ApproveQuestion(int id)
    {
        var question = await _context.Questions.FindAsync(id);
        if (question == null) return NotFound();

        question.Status = "Approved";
        await _context.SaveChangesAsync();
        return Ok("Approved");
    }

    [HttpPost("reject-question/{id}")]
    public async Task<IActionResult> RejectQuestion(int id)
    {
        var question = await _context.Questions.FindAsync(id);
        if (question == null) return NotFound();

        question.Status = "Rejected";
        await _context.SaveChangesAsync();
        return Ok("Rejected");
    }

    [HttpDelete("delete-question/{id}")]
    public async Task<IActionResult> DeleteQuestion(int id)
    {
        var question = await _context.Questions.FindAsync(id);
        if (question == null) return NotFound();

        _context.Questions.Remove(question);
        await _context.SaveChangesAsync();
        return Ok("Deleted");
    }

    [HttpPost("approve-answer/{id}")]
    public async Task<IActionResult> ApproveAnswer(int id)
    {
        var answer = await _context.Answers.FindAsync(id);
        if (answer == null) return NotFound();

        answer.Status = "Approved";
        await _context.SaveChangesAsync();
        return Ok("Approved");
    }

    [HttpPost("reject-answer/{id}")]
    public async Task<IActionResult> RejectAnswer(int id)
    {
        var answer = await _context.Answers.FindAsync(id);
        if (answer == null) return NotFound();

        answer.Status = "Rejected";
        await _context.SaveChangesAsync();
        return Ok("Rejected");
    }
}
