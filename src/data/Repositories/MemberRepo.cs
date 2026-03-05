using Microsoft.EntityFrameworkCore;
using src.Database;
using src.Models;

namespace api.Controllers;

public class MemberRepo(ApplicationDbContext _db)
{
    public async Task <List<Member>> GetMembers()
    {
        try
        {
            return await _db.Member
                .ToListAsync();

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
    }
}