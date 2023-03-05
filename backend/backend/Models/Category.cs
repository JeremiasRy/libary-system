namespace Backend.Models;

using System.ComponentModel.DataAnnotations;

public class Category : BaseModel
{
    [MinLength(2)]
    [MaxLength(50)]
    public string Title { get; set; } = null!;
    [MaxLength(50)]
    public string? Description { get; set; }
    public ICollection<Book> Books { get; set; } = null!;
}
