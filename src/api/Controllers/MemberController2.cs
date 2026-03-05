using DefaultNamespace;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[ApiController]
[Route("api/v2/members")]

public class MemberController2(MemberService2 memberService2) : ControllerBase
{
    [HttpPost]
    [Route("registerMember")]
    public async Task<IActionResult> RegisterMember(MemberDto2 dto2)
    {
        await memberService2.RegisterMember(dto2);
        return Ok();
    }
    
}