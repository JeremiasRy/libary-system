namespace backend.Services;

using backend.Models;
using backend.DTOs;
using backend.Db;

public class DbUserService : DbCrudService<User, UserDTO>
{
    public DbUserService(AppDbContext dbContext) : base(dbContext)
    {
    }
}
