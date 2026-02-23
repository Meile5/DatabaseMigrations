using System.ComponentModel.DataAnnotations;

namespace src.Models;

public class Member
{
    [Key]
    public Guid Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    public string LastName { get; set; }
    public virtual ICollection<Loan> Loans { get; set; }
}