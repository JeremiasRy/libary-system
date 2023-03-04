namespace backend.Models;

public class Book : BaseModel
{
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public ICollection<Category> Categories { get; set; } = null!;
    public ICollection<Author> Authors { get; set; } = null!;   
}
