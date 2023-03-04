using backend.Models;
using System.ComponentModel.DataAnnotations;

namespace backend.DTOs;

public class PublisherDTO : BaseDTO<Publisher>
{
    [Required]
    public string PublisherName { get; set; } = null!;
    public override void UpdateModel(Publisher model)
    {
        model.PublisherName = PublisherName;
    }
}
