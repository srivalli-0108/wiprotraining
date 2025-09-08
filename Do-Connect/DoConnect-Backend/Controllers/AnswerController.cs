using Microsoft.AspNetCore.Mvc;
using DoConnectBackend.Data;
using DoConnectBackend.Models;


[ApiController]
[Route("api/[controller]")]
public class AnswerController : ControllerBase
{
    private readonly DoConnectContext _context;

    public AnswerController(DoConnectContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var answers = _context.Answers.ToList();
        return Ok(answers);
    }

    [HttpPost]
    public IActionResult Post(Answer answer)
    {
        _context.Answers.Add(answer);
        _context.SaveChanges();
        return Ok(answer);
    }
}
