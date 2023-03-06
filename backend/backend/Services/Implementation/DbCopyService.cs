namespace Backend.Services;

using Backend.Models;
using Backend.DTOs;
using Backend.Db;
using System.Threading.Tasks;

public class DbCopyService : DbCrudService<Copy, CopyDTO>
{
    public DbCopyService(AppDbContext dbContext) : base(dbContext)
    {
    }
}
