using Backend.DTOs;
using Microsoft.AspNetCore.Identity;

namespace Backend.Services
{
    public interface IRoleService
    {
        Task<IdentityResult?> AddRole(RoleDTO request);
        Task<IdentityRole<int>?> GetRole(RoleDTO request);
    }
}