namespace api.Controllers;

public class BookRepo (ApplicationDbContext dbContext)
{
    
    public async Task<List<Comment>> GetComments(string articleId)
    {
        try
        {
            return await dbContext.Comments
                .Include(c => c.CommentUsers)
                .Where(c => c.ArticleId == articleId)
                .ToListAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
         
    }


    public async Task <List<BookAuthorDto>> GetBooks()
    {
        try
        {
            return result = await _db.Books
                .Include(b => b.BookAuthors)
                .ThenInclude(ba => ba.Author)
                .Select(b => new BookAuthorDto
                {
                    BookId = b.Id,
                    Title = b.Title,
                    Authors = b.BookAuthors.Select(ba => ba.Author.Name).ToList()
                })
                .ToListAsync();
            
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
    }
    
    
}