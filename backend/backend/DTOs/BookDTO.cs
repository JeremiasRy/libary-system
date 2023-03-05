namespace Backend.DTOs;

using Backend.Models;
using System.ComponentModel.DataAnnotations;

public class BookDTO : BaseDTO<Book>
{
    [Required]
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    public override void UpdateModel(Book model)
    {
        model.Title = Title;
        model.Description = Description;
    }
}
