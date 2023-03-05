using System.ComponentModel.DataAnnotations;

namespace Backend.DTOs;

public class AddAuthorDTO
{
    [Required]
    public int AuthorId { get; set; }
}
