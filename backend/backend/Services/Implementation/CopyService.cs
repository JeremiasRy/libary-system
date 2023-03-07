namespace Backend.Services;

using Backend.Models;
using Backend.DTOs;
using Backend.Db;
using System.Threading.Tasks;

public class CopyService : DbCrudService<Copy, CopyDTO>
{
    public CopyService(AppDbContext dbContext) : base(dbContext)
    {
    }
}
