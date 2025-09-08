using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using DoConnectAPI.Models;
using DoConnectAPI.Utilities;
using DoConnectAPI.Data;
using DoConnectAPI.Helpers;
using RegisterRequest = DoConnectAPI.Models.RegisterRequest;
using LoginRequest = DoConnectAPI.Models.LoginRequest;
using Microsoft.EntityFrameworkCore;


[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    private readonly IJwtTokenGenerator _tokenGenerator;

    public UserController(ApplicationDbContext context, IJwtTokenGenerator tokenGenerator)
    {
        _context = context;
        _tokenGenerator = tokenGenerator;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        var user = new User
        {
            Username = request.Username,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password),
            Role = request.Role
        };
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return Ok("User registered");
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == request.Username);
        if (user == null || !BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
            return Unauthorized("Invalid credentials");

        var token = _tokenGenerator.GenerateToken(user);
        return Ok(new { token, role = user.Role });
    }
}
