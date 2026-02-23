using System.ComponentModel.DataAnnotations;

namespace src.Models;

public class Book
{
    [Key]
    public Guid Id { get; set; }
    [Required]
    public string Title { get; set; }
    [Required]
    public string ISBN { get; set; }
    [Required]
    public DateTime PublishDate { get; set; }
    public virtual ICollection<Loan> Loans { get; set; }
}