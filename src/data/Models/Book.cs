using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace src.Models;

public class Book
{
    [Key]
    public Guid Id { get; set; }
    [Required]
    public string Title { get; set; }
    [Required]
    public string ISBN { get; set; }
    public string? ISBNNew { get; set; }
    [Required]
    public DateTime PublishDate { get; set; }
    [Required] 
    public bool isDeleted { get; set; } = false;
    public virtual ICollection<Loan> Loans { get; set; }
    public virtual ICollection<Loan2> Loans2 { get; set; }
    public virtual ICollection<BookAuthor> BookAuthors { get; set; }
}
