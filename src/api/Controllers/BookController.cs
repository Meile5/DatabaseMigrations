using DefaultNamespace;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;
[ApiController]
[Route("Books")]

public class BookController(BookService bookService) : ControllerBase
{
    [HttpGet]
    [Route("getBooksAuthors")]
    public async Task<IActionResult> GetBooksAuthors()
    {
        var dtos = await bookService.GetAvailableBooks();
        return Ok(dtos);
    }
}