using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace src.Models;

public class Loan2
{
    [Key]
    public Guid Id { get; set; }
    [Required]
    public Guid MemberId { get; set; }
    [Required]
    public Guid BookId { get; set; }
    [Required]
    public DateTime loanDate { get; set; }
    public DateTime? returnDate { get; set; }

    public string? Status { get; set; } = "Active";

    [ForeignKey(nameof(MemberId))]
    public virtual Member2 Member2 { get; set; }
    
    [ForeignKey(nameof(BookId))]
    public virtual Book Book { get; set; }
}