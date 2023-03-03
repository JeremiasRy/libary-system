namespace backend.Models;

public class Book : BaseModel
{
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
}
