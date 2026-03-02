using DefaultNamespace;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;
[ApiController]
[Route("Books")]

public class BookController(BookService bookService) : ControllerBase
{
    [HttpGet]
    [Route("getBooks")]
    public async Task<IActionResult> GetBooks()
    {
        var dtos = await bookService.GetBooks();
        return Ok(dtos);
    }
    
}