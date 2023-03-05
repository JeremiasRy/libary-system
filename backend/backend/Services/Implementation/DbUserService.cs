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
}
