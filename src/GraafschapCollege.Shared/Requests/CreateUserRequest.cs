namespace GraafschapCollege.Shared.Requests;

using System.ComponentModel.DataAnnotations;

public partial class CreateUserRequest
{
    [Required]
    public string Name { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    /// <summary>
    /// Password must contain at least one uppercase letter, 
    /// one lowercase letter, one number, one special character, and be between 8 and 15 characters long.
    /// </summary>
    [Required]
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$")]
    public string Password { get; set; }

    [Required]
    [Compare("Password")]
    public string RepeatPassword { get; set; }

    public List<string> Roles { get; set; }
}
