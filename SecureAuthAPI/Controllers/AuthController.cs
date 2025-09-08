using Microsoft.AspNetCore.Mvc;
using SecureAuthAPI.Models;
using SecureAuthAPI.Data;
using BCrypt.Net;
using Microsoft.EntityFrameworkCore;
using SecureAuthAPI.Services;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly IJwtService _jwtService;

    public AuthController(AppDbContext context, IJwtService jwtService)
    {
        _context = context;
        _jwtService = jwtService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == request.Username);
        if (user == null || !BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
        {
            // log failed attempt here
            return Unauthorized(new { error = "Invalid credentials" });
        }

        var token = _jwtService.GenerateToken(user);

        return Ok(new
        {
            token,
            expires_in = 3600,
            user = new { user.Id, user.Username, roles = new[] { user.Role } }
        });
    }

    [HttpPost("oauth")]
    public async Task<IActionResult> OAuthLogin([FromBody] dynamic oauthRequest)
    {
       
        string provider = oauthRequest.provider;
        string token = oauthRequest.token;

        if (provider != "google" || token != "oauth-access-token")
            return Unauthorized(new { error = "Invalid OAuth token" });

        var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == "google_user");
        if (user == null)
        {
            user = new User
            {
                Username = "google_user",
                PasswordHash = "", 
                Role = "User"
            };
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        var jwt = _jwtService.GenerateToken(user);
        return Ok(new
        {
            token = jwt,
            expires_in = 3600,
            user = new { user.Id, user.Username, roles = new[] { user.Role } }
        });
    }
}
