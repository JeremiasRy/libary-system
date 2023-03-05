namespace Backend.Services;

using Backend.Models;
using Backend.DTOs;
using Backend.Db;

public class DbPublisherService : DbCrudService<Publisher, PublisherDTO>
{
    public DbPublisherService(AppDbContext dbContext) : base(dbContext)
    {
    }
}
