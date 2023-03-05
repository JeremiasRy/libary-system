namespace backend.Services;

using backend.Models;
using backend.DTOs;
using backend.Db;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

public class DbAuthorService : DbCrudService<Author, AuthorDTO>
{
    public DbAuthorService(AppDbContext dbContext) : base(dbContext)
    {
    }
}
