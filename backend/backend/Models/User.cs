namespace Backend.Models;

using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

public class User : IdentityUser<int>
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
    public ICollection<Loan> Loans { get; set; } = null!;   
}
