namespace backend.Models;

public class Category : BaseModel
{
    public string Title { get; set; } = null!;
    public ICollection<Book> Books { get; set; } = null!;
}
