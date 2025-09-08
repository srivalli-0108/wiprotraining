namespace DoConnectAPI.Models
{
    public class LoginRequest
    {
        public string Username { get; set; } = string.Empty;  // <-- required
        public string Password { get; set; } = string.Empty;
    }
}
