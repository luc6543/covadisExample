namespace GraafschapCollege.Api.Entities;

using System.ComponentModel.DataAnnotations;

public class Role
{
    public const string Administrator = "Administrator";
    public const string Employee = "Employee";

    [Key]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    public virtual ICollection<User> Users { get; set; }
}