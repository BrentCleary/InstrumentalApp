#pragma warning disable 8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using TeamFive.Attributes;

namespace TeamFive.Models;
public class User : BaseEntity
{
    [Key]
    public int UserId { get; set; }

    [Required]
    [StringLength(50, ErrorMessage = "The {0} must be at least {2} and no more than {1} characters long.", MinimumLength = 2)]
    public string FirstName { get; set; }

    [Required]
    [StringLength(50, ErrorMessage = "The {0} must be at least {2} and no more than {1} characters long.", MinimumLength = 2)]
    public string LastName { get; set; }

    [Required]
    [EmailAddress]
    [UniqueEmail]
    public string Email { get; set; }

    [Required]
    [MinLength(8)]
    [StrongPassword]
    public string Password { get; set; }

    [NotMapped]
    [Compare("Password")]
    public string Confirm { get; set; }

    //Associations
    public Role? Role { get; set; }

    public virtual ICollection<RefreshToken> RefreshTokens { get; set; } = new List<RefreshToken>();
    public virtual ICollection<Lesson> TaughtLessons { get; set; } = new List<Lesson>();
    public virtual ICollection<Lesson> AttendedLessons { get; set; } = new List<Lesson>();
    public virtual ICollection<UserInstrument> UserInstruments { get; set; } = new List<UserInstrument>();
}
