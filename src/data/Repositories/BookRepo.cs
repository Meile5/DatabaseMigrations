using DefaultNamespace;
using Microsoft.EntityFrameworkCore;
using src.Database;

namespace api.Controllers;

public class BookRepo
{
    private readonly ApplicationDbContext _db;

    public BookRepo(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<List<BookAuthorDto>> GetBooks()
    {
        try
        {
            return await _db.Book
                .Include(b => b.BookAuthors)
                .ThenInclude(ba => ba.Author)
                .Select(b => new BookAuthorDto
                {
                    BookId = b.Id,
                    Title = b.Title,
                    Authors = b.BookAuthors.Select(ba => new AuthorDto
                    {
                        FirstName = ba.Author.FirstName,
                        LastName = ba.Author.LastName
                    }).ToList()
                })
                .ToListAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    public async Task<List<BookAuthorDto>> GetAvailableBooks()
    {
        try
        {
            return await _db.Book
                .Where(b=>!b.isDeleted)    
                .Include(b => b.BookAuthors)
                .ThenInclude(ba => ba.Author)
                .Select(b => new BookAuthorDto
                {
                    BookId = b.Id,
                    Title = b.Title,
                    Authors = b.BookAuthors.Select(ba => new AuthorDto
                    {
                        FirstName = ba.Author.FirstName,
                        LastName = ba.Author.LastName
                    }).ToList()
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