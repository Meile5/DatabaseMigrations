using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[ApiController]
[Route("Book")]

public class LoansCController : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetLoan()
    {
        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> AddLoan(string memberId)
    {
        return Ok();
    }
    
}