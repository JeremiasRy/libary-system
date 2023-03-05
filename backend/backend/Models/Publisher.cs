using System.ComponentModel.DataAnnotations;

namespace backend.Models;

public class Publisher : BaseModel
{
    [MinLength(2)]
    [MaxLength(50)]
    public string PublisherName { get; set; } = null!;
    public ICollection<Copy> Copies { get; set; } = null!;
}
