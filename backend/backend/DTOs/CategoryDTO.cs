namespace backend.DTOs;

using backend.Models;
using System.ComponentModel.DataAnnotations;

public class CategoryDTO : BaseDTO<Category>
{
    [Required]
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    public override void UpdateModel(Category model)
    {
        model.Title = Title;
        model.Description = Description;
    }
}
