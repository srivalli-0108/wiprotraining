using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

public class CustomIsbnAttribute : ValidationAttribute
{
   protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
{
    var isbn = value as string;

    if (string.IsNullOrEmpty(isbn))
        return new ValidationResult("ISBN is required.");

    if (!Regex.IsMatch(isbn, @"^\d{3}-\d{10}$"))
        return new ValidationResult("Invalid ISBN format (expected: 000-0000000000).");

    return ValidationResult.Success;
}

}
