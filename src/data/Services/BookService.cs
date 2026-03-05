using DefaultNamespace;

namespace api.Controllers;

public class BookService (BookRepo repo)
{
    public async Task<List<BookAuthorDto>> GetBooks()
    {
        return await repo.GetBooks();
    }

    public async Task<List<BookAuthorDto>> GetAvailableBooks()
    {
        return await repo.GetAvailableBooks();
    }
}