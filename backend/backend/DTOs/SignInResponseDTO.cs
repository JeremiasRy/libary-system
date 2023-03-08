namespace Backend.DTOs;

public class SignInResponseDTO
{
    public string Token { get; set; } = null!;
    public DateTime ExpiresAt { get; set; } 

}
