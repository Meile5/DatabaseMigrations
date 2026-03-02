using DefaultNamespace;


namespace api.Controllers;

public class LoanService2(LoanRepo2 repo)
{
    public async Task<List<LoanDto2>> GetLoans(string memberId)
    {
        return await repo.GetLoans(memberId);
    }
}