// File: DTOs/LoginRequest.cs
using System.ComponentModel.DataAnnotations;

namespace DoConnectBackend.DTOs
{
    public class LoginRequest
    {
        [Required]
        public string? Username { get; set; }

        [Required]
        public string? Password { get; set; }
    }
}
