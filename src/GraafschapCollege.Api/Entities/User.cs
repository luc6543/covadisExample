namespace GraafschapCollege.Api.Entities;

using Microsoft.EntityFrameworkCore;

using System.ComponentModel.DataAnnotations;

[Index(nameof(Email), IsUnique = true)]
public class User
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public string Email { get; set; }

    [Required]
    public string Password { get; set; }

    public virtual ICollection<Role> Roles { get; set; }
}
