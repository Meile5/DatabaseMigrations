using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[ApiController]
[Route("api/loans")]

public class LoansController(LoanService service) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetLoans(string memberId)
    {
        var loans = await service.GetLoans(memberId);
        return Ok(loans);
    }

    [HttpPost]
    public async Task<IActionResult> AddLoan(string memberId)
    {
        return Ok();
    }
    
}