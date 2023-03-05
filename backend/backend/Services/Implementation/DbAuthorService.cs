namespace Backend.Services;

using Backend.Models;
using Backend.DTOs;
using Backend.Db;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

public class DbAuthorService : DbCrudService<Author, AuthorDTO>
{
    public DbAuthorService(AppDbContext dbContext) : base(dbContext)
    {
    }
}
