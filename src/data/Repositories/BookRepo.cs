namespace api.Controllers;

public class BookRepo (AppDbContext dbContext)
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
                .Join(_db.BookAuthors, b => b.Id, ba => ba.BookId, (b, ba) => new { b, ba })
                .Join(_db.Authors, x => x.ba.AuthorId, a => a.Id, (x, a) => new BookAuthorDto
                {
                    BookId = x.b.BookId,
                    Title = x.b.Title,
                    AuthorName = a.Name
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