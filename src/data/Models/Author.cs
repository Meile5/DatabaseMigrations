using System.ComponentModel.DataAnnotations;

namespace src.Models;

public class Author

{
    [Key]
    public Guid Id { get; set; }
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    public string? Biography { get; set; }
    
    public virtual ICollection<Loan> Loans { get; set; }
    public virtual ICollection<BookAuthor> BookAuthors { get; set; }
}