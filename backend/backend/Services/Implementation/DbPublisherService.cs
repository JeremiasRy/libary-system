namespace backend.Services;

using backend.Models;
using backend.DTOs;
using backend.Db;

public class DbPublisherService : DbCrudService<Publisher, PublisherDTO>
{
    public DbPublisherService(AppDbContext dbContext) : base(dbContext)
    {
    }
}
