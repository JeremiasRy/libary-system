using Backend.DTOs;
using Backend.Models;

namespace Backend.Services;
    
public interface IJwtTokenService
{
    Task<SignInResponseDTO?> GenerateToken(User user);
}