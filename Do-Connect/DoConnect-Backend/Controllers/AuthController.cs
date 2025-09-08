using Microsoft.AspNetCore.Mvc;
using DoConnectBackend.DTOs;
using DoConnectBackend.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using DoConnectBackend.Data;

namespace DoConnect.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly DoConnectContext _context;

        public AuthController(IConfiguration configuration, DoConnectContext context)
        {
            _configuration = configuration;
            _context = context;
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingUser = _context.Users.FirstOrDefault(u => u.Username == request.Username);
            if (existingUser != null)
                return Conflict("Username already exists");

            // ✅ Null-coalescing to avoid CS8601
            var user = new User
            {
                Name = request.Username ?? string.Empty,
                Password = request.Password ?? string.Empty,
                Role = "User"
            };

            _context.Users.Add(user);
            _context.SaveChanges();

            return Ok(new { message = "User registered successfully" });
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = _context.Users.FirstOrDefault(u =>
                u.Name == request.Username && u.Password == request.Password);

            if (user == null)
                return Unauthorized("Invalid credentials");

            // ✅ Fix CS8604 by validating config values first
            var jwtKey = _configuration["Jwt:Key"];
            var jwtIssuer = _configuration["Jwt:Issuer"];
            var jwtAudience = _configuration["Jwt:Audience"];

            if (string.IsNullOrWhiteSpace(jwtKey))
                return StatusCode(500, "JWT Key not configured");

            if (string.IsNullOrWhiteSpace(jwtIssuer) || string.IsNullOrWhiteSpace(jwtAudience))
                return StatusCode(500, "JWT Issuer or Audience not configured");

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.Name ?? ""),
                new Claim(ClaimTypes.Role, user.Role ?? "User"),
                new Claim("Id", user.Id.ToString())
            };

            var token = new JwtSecurityToken(
                issuer: jwtIssuer,
                audience: jwtAudience,
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: creds
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            return Ok(new { token = tokenString });
        }
    }
}
