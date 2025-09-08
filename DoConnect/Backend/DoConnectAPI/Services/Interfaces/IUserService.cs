using DoConnectAPI.DTOs;
using DoConnectAPI.Models;

namespace DoConnectAPI.Services.Interfaces
{
    public interface IUserService
    {
        Task<User> RegisterUserAsync(RegisterRequest request);
        Task<string> LoginUserAsync(LoginRequest request);
    }
}
