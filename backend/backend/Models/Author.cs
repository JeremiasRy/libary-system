namespace backend.Models;

public class Author : BaseModel
{
    public string Firstname { get; set; } = null!;
    public string Lastname { get; set; } = null!;
}
