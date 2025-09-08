using System.ComponentModel.DataAnnotations;

namespace DoConnectBackend.DTOs
{
    public class RegisterRequest
    {
        [Required]
        public string? Username { get; set; }

        [Required]
        public string? Password { get; set; }

        public string Role { get; set; } = "User";
    }
}
