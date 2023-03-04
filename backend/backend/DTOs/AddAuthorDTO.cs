using System.ComponentModel.DataAnnotations;

namespace backend.DTOs;

public class AddAuthorDTO
{
    [Required]
    public int AuthorId { get; set; }
}
