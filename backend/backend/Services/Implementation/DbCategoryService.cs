namespace backend.Services;

using backend.Models;
using backend.DTOs;
using backend.Db;

public class DbCategoryService : DbCrudService<Category, CategoryDTO>
{
    public DbCategoryService(AppDbContext dbContext) : base(dbContext)
    {
    }
}