namespace Backend.Services;

using Backend.Models;
using Backend.DTOs;
using Backend.Db;

public class DbCategoryService : DbCrudService<Category, CategoryDTO>
{
    public DbCategoryService(AppDbContext dbContext) : base(dbContext)
    {
    }
}