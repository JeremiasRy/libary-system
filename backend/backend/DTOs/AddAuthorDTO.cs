using System.ComponentModel.DataAnnotations;

namespace Backend.DTOs;

public class AddDTO
{
    [Required]
    public int AddId { get; set; }
}
