using System.ComponentModel.DataAnnotations;

public class RegisterViewModel
{
    [Required]
    [EmailAddress]
    public string? Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    [StringLength(100, MinimumLength = 8)]
    [RegularExpression(@"^(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&]).{8,}$", ErrorMessage = "Password must meet requirements.")]
    public string? Password { get; set; }

    [DataType(DataType.Password)]
    [Compare("Password")]
    public string? ConfirmPassword { get; set; }
}
