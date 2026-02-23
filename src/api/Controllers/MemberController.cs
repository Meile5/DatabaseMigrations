using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[ApiController]
[Route("Book")]

public class MemberController : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetMember()
    {
        return Ok();
    }
    
}