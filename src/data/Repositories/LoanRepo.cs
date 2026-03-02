using DefaultNamespace;
using Microsoft.EntityFrameworkCore;
using src.Database;
using src.Models;

namespace api.Controllers;


public class LoanRepo(ApplicationDbContext _db)
{
    public async Task <List<LoanDto>> GetLoans(string memberId)
    {
        var guid = new Guid(memberId);
        try
        {
            return await _db.Loan
                .Include(b => b.Book)
                .Where(l => l.MemberId == guid)
                .Select(l => new LoanDto
                {
                    Id = l.Id,
                    Title = l.Book.Title,
                    loanDate = l.loanDate,
                    returnDate = l.returnDate
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