using DefaultNamespace;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;


[ApiController]
[Route("api/v1/members")]

public class MemberController(MemberService memberService): ControllerBase
{
    [HttpGet]
    [Route("getMember")]
    public async Task<IActionResult> GetMember()
    {
        var members = await memberService.GetMembers();
        return Ok(members);
    }
}