namespace Backend.Models;

using System.ComponentModel.DataAnnotations;

public class Book : BaseModel
{
    [MinLength(2)]
    [MaxLength(50)]
    public string Title { get; set; } = null!;
    [MaxLength(256)]
    public string? Description { get; set; }
    public ICollection<Category> Categories { get; set; } = null!;
    public ICollection<Author> Authors { get; set; } = null!;  
    public ICollection<Copy> Copies { get; set; } = null!;
}
