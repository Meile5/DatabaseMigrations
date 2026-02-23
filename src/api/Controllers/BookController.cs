using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;
[ApiController]
[Route("Book")]

public class BookController : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetBook()
    {
        return Ok();
    }
    
}