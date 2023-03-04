namespace backend.Models;

using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class User : BaseModel
{
    [MinLength(2)]
    public string Firstname { get; set; } = null!;

    [MinLength(2)]
    public string Lastname { get; set; } = null!;

    [NotMapped]
    [JsonIgnore]
    public string Fullname => $"{Firstname} {Lastname}";

    [MinLength(4)]
    public string Username { get; set; } = null!;

    [EmailAddress]
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public ICollection<CartItem> CartItems { get; set; } = null!;
    public ICollection<Loan> Loans { get; set; } = null!;
    public UserRole Role { get; set; }
    public enum UserRole
    {
        Customer,
        Admin
    }
}
