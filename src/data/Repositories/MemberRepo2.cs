using src.Database;
using src.Models;

namespace api.Controllers;

public class MemberRepo2(ApplicationDbContext _db)
{
    public async Task RegisterMember(Member2 member)
    {
        try
        {
            await _db.Member2
                .AddAsync(member);
            
            await _db.SaveChangesAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
    }
}