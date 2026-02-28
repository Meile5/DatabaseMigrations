using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using src.Models;

public class BookAuthor
{
    
    [Key]
    public Guid Id { get; set; }
    
    [Required]
    public Guid BookId { get; set; }
    
    [Required]
    public Guid AuthorId { get; set; }
    
    [ForeignKey(nameof(AuthorId))]
    public virtual Author Author { get; set; }
    
    [ForeignKey(nameof(BookId))]
    public virtual Book Book { get; set; }
}