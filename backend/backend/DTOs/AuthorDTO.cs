namespace backend.DTOs;

using backend.Models;
using System.ComponentModel.DataAnnotations;

public class AuthorDTO : BaseDTO<Author>
{
    [Required]
    public string Firstname { get; set; } = null!;
    [Required]
    public string Lastname { get; set; } = null!;
    public override void UpdateModel(Author model)
    {
        model.Firstname = Firstname;
        model.Lastname = Lastname;
    }
}
