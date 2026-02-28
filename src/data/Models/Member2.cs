using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;

namespace src.Models;
[Index(nameof(Email), IsUnique = true)]
public class Member2
{
    [Key]
    public Guid Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required] 
    public string Email { get; set; }
    [Required]
    public string Phone { get; set; }
    [Required]
    public string LastName { get; set; }
    public virtual ICollection<Loan2> Loans2 { get; set; }
}