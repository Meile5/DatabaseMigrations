using DefaultNamespace;
using Microsoft.EntityFrameworkCore;
using src.Database;
using src.Models;

namespace api.Controllers;


public class LoanRepo2(ApplicationDbContext _db)
{
    public async Task <List<LoanDto2>> GetLoans(string memberId)
    {
        var guid = new Guid(memberId);
        try
        {
            return await _db.Loan2
                .Include(b => b.Book)
                .Where(l => l.MemberId == guid)
                .Select(l => new LoanDto2
                {
                    Id = l.Id,
                    Title = l.Book.Title,
                    loanDate = l.loanDate,
                    returnDate = l.returnDate,
                    Status = l.Status
                })
                .ToListAsync();

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
    }
}