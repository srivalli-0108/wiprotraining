using DoConnectAPI.DTOs;
using DoConnectAPI.Models;
using DoConnectAPI.Services.Interfaces;
using DoConnectAPI.Data;
using Microsoft.EntityFrameworkCore;
using DoConnectAPI.Helpers;

namespace DoConnectAPI.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;
        private readonly IJwtTokenGenerator _jwt;

        public UserService(ApplicationDbContext context, IJwtTokenGenerator jwt)
        {
            _context = context;
            _jwt = jwt;
        }

        public async Task<User> RegisterUserAsync(RegisterRequest request)
        {
            var existing = await _context.Users.AnyAsync(u => u.Username == request.Username);
            if (existing) throw new Exception("Username already exists.");

            var user = new User
            {
                Username = request.Username,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password),
                Role = request.Role
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<string> LoginUserAsync(LoginRequest request)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == request.Username);
            if (user == null || !BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
                throw new UnauthorizedAccessException("Invalid credentials.");

            return _jwt.GenerateToken(user);
        }
    }
}
