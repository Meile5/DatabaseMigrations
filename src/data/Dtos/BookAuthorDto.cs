namespace DefaultNamespace;

public class BookAuthorDto
{
    public Guid BookId { get; set; } 
    public string BookName { get; set; } 
    public DateTime PublishDate { get; set; }
    public string ISBN { get; set; }
    public List <AuthorDto> Authors { get; set; }
}