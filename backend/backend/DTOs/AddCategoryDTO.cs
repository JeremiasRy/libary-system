using System.ComponentModel.DataAnnotations;

namespace Backend.DTOs;

public class AddCategoryDTO
{
    [Required]
    public int CategoryId { get; set; }
}
