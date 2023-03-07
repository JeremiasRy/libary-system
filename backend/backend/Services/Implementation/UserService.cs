namespace Backend.Services;

using Backend.DTOs;
using Backend.Models;
using Microsoft.AspNetCore.Identity;

public class UserService
{
    private readonly UserManager<User> _userManager;
    public UserService(UserManager<User> userManager) => _userManager = userManager;
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
    public async Task<bool> AssignRolesToUser(string[] roles, User user)
    {
        var result = await _userManager.AddToRolesAsync(user, roles);
        return result.Succeeded;
    }
}
