namespace backend.Services.Implementation;

using backend.Models;
using backend.DTOs;
using backend.Db;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

public class DbPublisherService : DbCrudService<Publisher, PublisherDTO>
{
    public DbPublisherService(AppDbContext dbContext) : base(dbContext)
    {
    }
}
