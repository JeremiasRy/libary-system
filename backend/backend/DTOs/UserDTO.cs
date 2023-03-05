namespace Backend.DTOs;

using Backend.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class UserDTO : BaseDTO<User>, IValidatableObject 
{
    public string Username { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string Firstname { get; set; } = null!;
    public string Lastname { get; set; } = null!;
    [EmailAddress]
    public string Email { get; set; } = null!;
    public User.UserRole UserRole { get; set; }
    public override void UpdateModel(User model)
    {
        model.Username = Username;
        model.Password = Password;
        model.Email = Email;
        model.Firstname = Firstname;
        model.Lastname = Lastname;
        model.Role = UserRole;
    }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (Username.Length < 5)
        {
            yield return new ValidationResult("Username is not long enough");
        }
        if (Password.Length < 8)
        {
            yield return new ValidationResult("Password is not strong enough");
        }
        if (Firstname.Length < 2)
        {
            yield return new ValidationResult("Firstname is not long enough");
        }
        if (Lastname.Length < 2)
        {
            yield return new ValidationResult("Lastname is not long enough");
        }
    }
}
