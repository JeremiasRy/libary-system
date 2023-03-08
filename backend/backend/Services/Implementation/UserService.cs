namespace Backend.Services;

using Backend.DTOs;
using Backend.Models;
using Microsoft.AspNetCore.Identity;

public class UserService : IUserService
{
    private readonly UserManager<User> _userManager;
    private readonly IJwtTokenService _jwtTokenService;
    public UserService(UserManager<User> userManager, IJwtTokenService JwtTokenService)
    {
        _userManager = userManager;
        _jwtTokenService = JwtTokenService;
    }
    public async Task<User?> SignUp(RegisterDTO request)
    {
        var user = new User()
        {
            UserName = request.Username,
            Firstname = request.Firstname,
            Lastname = request.Lastname,
            Email = request.Email
        };

        var result = await _userManager.CreateAsync(user, request.Password);
        if (!result.Succeeded)
        {
            return null;
        }
        return user;
    }
    public async Task<SignInResponseDTO?> SignIn(CredentialsDTO request)
    {
        var user = await _userManager.FindByEmailAsync(request.Email);

        if (!await _userManager.CheckPasswordAsync(user, request.Password))
        {
            return null;
        }
        return await _jwtTokenService.GenerateToken(user);

    }
    public async Task<bool> AssignRolesToUser(string[] roles, User user)
    {
        var result = await _userManager.AddToRolesAsync(user, roles);
        return result.Succeeded;
    }
}
