namespace DefaultNamespace;

public class LoanDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public DateTime loanDate { get; set; }
    public DateTime? returnDate { get; set; }
}