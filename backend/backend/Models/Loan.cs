namespace Backend.Models;

public class Loan : BaseModel
{
    public int CopyId { get; set; }
    public Copy Copy { get; set; } = null!;
    public int UserId { get; set; }
    public User User { get; set; } = null!;
    public DateTime LoanedAt { get; set; }
    public DateTime DueDate { get; set; }
    public bool Returned { get; set; } = false;
    public bool ShouldBeReturned { get => DateTime.Now > DueDate; }

}
