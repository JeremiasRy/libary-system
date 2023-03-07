namespace Backend.Services;

using Backend.Models;
using Backend.DTOs;
using Backend.Db;

public class CategoryService : DbCrudService<Category, CategoryDTO>
{
    public CategoryService(AppDbContext dbContext) : base(dbContext)
    {
    }
}