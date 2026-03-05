using DefaultNamespace;
using src.Models;

namespace api.Controllers;

public class MemberService(MemberRepo repo)
{
    
    public async Task <List<MemberDto>> GetMembers()
    {
        var members = await repo.GetMembers();
        var newDtoList = new List<MemberDto>();
        foreach (var member in members)
        {
            var memberDto = new MemberDto
            {
                Name = member.Name,
                LastName = member.LastName,
                Email = member.Email,
            };
            newDtoList.Add(memberDto);
        }
        return newDtoList;
    }
}