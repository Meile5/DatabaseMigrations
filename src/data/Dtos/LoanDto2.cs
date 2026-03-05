namespace DefaultNamespace;

public class LoanDto2
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public DateTime loanDate { get; set; }
    public DateTime? returnDate { get; set; }
    public string? Status { get; set; }
}