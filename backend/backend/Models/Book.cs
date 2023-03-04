namespace backend.Models;

using System.ComponentModel.DataAnnotations;

public class Book : BaseModel
{
    [MinLength(2)]
    [MaxLength(50)]
    public string Title { get; set; } = null!;
    [MaxLength(256)]
    public string? Description { get; set; }
    public ICollection<BookCategory> BookCategoryLinks { get; set; } = null!;
    public ICollection<BookAuthor> BookAuthorLinks { get; set; } = null!;  
    public ICollection<Copy> Copies { get; set; } = null!;
}
