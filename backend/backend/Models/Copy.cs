namespace Backend.Models;

public class Copy : BaseModel
{
    public bool IsAvailable { get; set; } = true;
    public int PublisherId { get; set; }
    public Publisher Publisher { get; set; } = null!;
    public int BookId { get; set; }
    public Book Book { get; set; } = null!;
    public ICollection<Loan> Loans { get; set; } = null!;
}
