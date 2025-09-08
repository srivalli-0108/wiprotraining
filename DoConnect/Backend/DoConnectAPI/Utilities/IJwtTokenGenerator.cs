using DoConnectAPI.Models;

namespace DoConnectAPI.Helpers
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(User user);
    }
}
