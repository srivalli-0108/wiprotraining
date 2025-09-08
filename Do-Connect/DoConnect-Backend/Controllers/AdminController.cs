

using DoConnectBackend.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DoConnectB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")] // ✅ Admin-only access
    public class AdminController : ControllerBase
    {
        private readonly DoConnectContext _context;

        public AdminController(DoConnectContext context)
        {
            _context = context;
        }

        // ✅ GET: All Users
        [HttpGet("users")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _context.Users.ToListAsync();
            return Ok(users);
        }

        // ✅ GET: Single User
        [HttpGet("users/{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return NotFound("User not found.");
            return Ok(user);
        }

        // ✅ POST: Create New User
        [HttpPost("users")]
        public async Task<IActionResult> CreateUser([FromBody] User user)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var existing = await _context.Users.FirstOrDefaultAsync(u => u.Username == user.Username);
            if (existing != null) return BadRequest("Username already exists.");

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return Ok(user);
        }

        // ✅ PUT: Update User
        [HttpPut("users/{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] User updatedUser)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return NotFound("User not found.");

            user.Username = updatedUser.Username;
            user.Password = updatedUser.Password; // Hash in real apps
            user.Role = updatedUser.Role;

            await _context.SaveChangesAsync();
            return Ok(user);
        }

        // ✅ DELETE: Remove User
        [HttpDelete("users/{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return NotFound("User not found.");

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return Ok("User deleted.");
        }

        // ✅ GET: All Questions (Pending Approval)
        [HttpGet("questions/pending")]
        public async Task<IActionResult> GetPendingQuestions()
        {
            var questions = await _context.Questions
                .Where(q => q.Status == "Pending")
                .Include(q => q.User)
                .ToListAsync();

            return Ok(questions);
        }

        // ✅ PUT: Approve/Reject Question
        [HttpPut("questions/{id}/approve")]
        public async Task<IActionResult> ApproveQuestion(int id, [FromQuery] string status)
        {
            var question = await _context.Questions.FindAsync(id);
            if (question == null) return NotFound("Question not found.");

            if (status != "Approved" && status != "Rejected")
                return BadRequest("Invalid status. Use 'Approved' or 'Rejected'.");

            question.Status = status;
            await _context.SaveChangesAsync();

            return Ok($"Question marked as {status}.");
        }

        // ✅ DELETE: Inappropriate Question
        [HttpDelete("questions/{id}")]
        public async Task<IActionResult> DeleteQuestion(int id)
        {
            var question = await _context.Questions.FindAsync(id);
            if (question == null) return NotFound("Question not found.");

            _context.Questions.Remove(question);
            await _context.SaveChangesAsync();
            return Ok("Question deleted.");
        }

        // ✅ GET: All Answers (Pending Approval)
        [HttpGet("answers/pending")]
        public async Task<IActionResult> GetPendingAnswers()
        {
            var answers = await _context.Answers
                .Where(a => a.Status == "Pending")
                .Include(a => a.User)
                .Include(a => a.Question)
                .ToListAsync();

            return Ok(answers);
        }

        // ✅ PUT: Approve/Reject Answer
        [HttpPut("answers/{id}/approve")]
        public async Task<IActionResult> ApproveAnswer(int id, [FromQuery] string status)
        {
            var answer = await _context.Answers.FindAsync(id);
            if (answer == null) return NotFound("Answer not found.");

            if (status != "Approved" && status != "Rejected")
                return BadRequest("Invalid status. Use 'Approved' or 'Rejected'.");

            answer.Status = status;
            await _context.SaveChangesAsync();

            return Ok($"Answer marked as {status}.");
        }

        // ✅ DELETE: Inappropriate Answer
        [HttpDelete("answers/{id}")]
        public async Task<IActionResult> DeleteAnswer(int id)
        {
            var answer = await _context.Answers.FindAsync(id);
            if (answer == null) return NotFound("Answer not found.");

            _context.Answers.Remove(answer);
            await _context.SaveChangesAsync();
            return Ok("Answer deleted.");
        }
    }
}
