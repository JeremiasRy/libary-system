namespace Backend.Models;

using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Author : BaseModel
{
    [MinLength(2)]
    [MaxLength(50)]
    public string Firstname { get; set; } = null!;
    [MinLength(2)]
    [MaxLength(50)]
    public string Lastname { get; set; } = null!;
    [NotMapped]
    [JsonIgnore]
    public string Fullname => $"{Firstname} {Lastname}";
    public ICollection<Book> Books { get; set; } = null!;
}
