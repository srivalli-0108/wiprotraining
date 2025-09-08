using SecureAuthAPI.Models;

namespace SecureAuthAPI.Services
{
    public interface IJwtService
    {
        string GenerateToken(User user);
    }
}
