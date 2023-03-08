using Backend.DTOs;
using Backend.Models;

namespace Backend.Services
{
    public interface IUserService
    {
        Task<bool> AssignRolesToUser(string[] roles, User user);
        Task<User?> SignUp(RegisterDTO request);
        Task<SignInResponseDTO> SignIn(CredentialsDTO request);
    }
}