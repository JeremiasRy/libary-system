namespace backend.Services.Implementation;

using backend.Models;
using backend.DTOs;
using backend.Db;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

public class DbUserService : DbCrudService<User, UserDTO>
{
    public DbUserService(AppDbContext dbContext) : base(dbContext)
    {
    }
    public override async Task<ICollection<User>> GetAllAsync()
    {
        return await _dbContext
            .Set<User>()
            .Include(user => user.CartItems)
            .Include(user => user.Loans)
            .ToListAsync();
    }
    public async override Task<User?> GetByIdAsync(int id)
    {
        var users = await GetAllAsync();

        return users.FirstOrDefault(user => user.Id == id);
    }
}
