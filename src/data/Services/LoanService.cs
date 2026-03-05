using DefaultNamespace;


namespace api.Controllers;

public class LoanService(LoanRepo repo)
{
    public async Task<List<LoanDto>> GetLoans(string memberId)
    {
        return await repo.GetLoans(memberId);
    }
}