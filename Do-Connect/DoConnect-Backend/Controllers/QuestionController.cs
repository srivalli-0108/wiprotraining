using Microsoft.AspNetCore.Mvc;
using DoConnectBackend.Models;
using DoConnectBackend.Data;

[ApiController]
[Route("api/[controller]")]
public class QuestionController : ControllerBase
{
    private readonly DoConnectContext _context;

    public QuestionController(DoConnectContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var questions = _context.Questions.ToList();
        return Ok(questions);
    }

    [HttpPost]
    public IActionResult Post(Question question)
    {
        _context.Questions.Add(question);
        _context.SaveChanges();
        return Ok(question);
    }
}
