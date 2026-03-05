using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[ApiController]
[Route("api/v2/loans")]

public class LoansController2(LoanService2 service) : ControllerBase
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