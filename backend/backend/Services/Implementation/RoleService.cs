namespace Backend.Services;

using Backend.DTOs;
using Microsoft.AspNetCore.Identity;

public class RoleService : IRoleService
{
    private readonly RoleManager<IdentityRole<int>> _roleManager;
    public RoleService(RoleManager<IdentityRole<int>> roleManager) => _roleManager = roleManager;

    public async Task<IdentityResult?> AddRole(RoleDTO request)
    {
        var result = await _roleManager.CreateAsync(new IdentityRole<int>() { Name = request.RoleName });
        return result;
    }
    public async Task<IdentityRole<int>?> GetRole(RoleDTO request)
    {
        return await _roleManager.FindByNameAsync(request.RoleName);
    }

}
