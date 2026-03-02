using DefaultNamespace;
using src.Models;

namespace api.Controllers;

public class MemberService2(MemberRepo2 repo2)
{
    public async Task RegisterMember(MemberDto2 memberDto2)
    {
        var member = new Member2
        {
            Name = memberDto2.Name,
            LastName = memberDto2.LastName,
            Email = memberDto2.Email,
            Phone = memberDto2.PhoneNumber,
            Id = new Guid()

        };
        await repo2.RegisterMember(member);
    }
}