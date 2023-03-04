using System.ComponentModel.DataAnnotations;

namespace backend.DTOs;

public class AddCategoryDTO
{
    [Required]
    public int CategoryId { get; set; }
}
