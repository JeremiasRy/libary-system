namespace Backend.Services;

using Backend.Models;
using Backend.DTOs;
using Backend.Db;

public class DbUserService : DbCrudService<User, UserDTO>
{
    public DbUserService(AppDbContext dbContext) : base(dbContext)
    {
    }
}
