namespace backend.Models;

public class Copy : BaseModel
{
    public bool IsAvailable { get; set; }
    public Publisher Publisher { get; set; } = null!;
    public Book Book { get; set; } = null!;
    public int BookId { get; set; }
    public int PublisherId { get; set; }
}
