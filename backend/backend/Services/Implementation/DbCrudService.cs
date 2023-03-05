namespace backend.Services;

using backend.Db;
using backend.DTOs;
using backend.Models;
using Microsoft.EntityFrameworkCore;

public abstract class DbCrudService<TModel, TDto> : ICrudService<TModel, TDto>
    where TModel : BaseModel, new()
    where TDto : BaseDTO<TModel>
{
    protected readonly AppDbContext _dbContext;
    public DbCrudService(AppDbContext dbContext) => _dbContext = dbContext;

    public virtual async Task<TModel?> CreateAsync(TDto request)
    {
        TModel item = new();
        request.UpdateModel(item);
        _dbContext.Add(item);
        await _dbContext.SaveChangesAsync();
        return item;
    }

    public virtual async Task<bool> DeleteAsync(int id)
    {
        var item = await _dbContext.FindAsync<TModel>(id);
        if (item is null)
        {
            return false;
        } 
        _dbContext.Remove(item);
        await _dbContext.SaveChangesAsync();
        return true;
    }

    public virtual async Task<ICollection<TModel>> GetAllAsync(int page = 1, int pageSize = 50)
    {
        return await _dbContext
            .Set<TModel>()
            .AsNoTracking()
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }

    public virtual async Task<TModel?> GetByIdAsync(int id)
    {
        return await _dbContext.Set<TModel>().FindAsync(id);
    }

    public virtual async Task<TModel?> UpdateAsync(int id, TDto request)
    {
        var item = await GetByIdAsync(id);
        if (item is null)
        {
            return null;
        }
        request.UpdateModel(item);
        await _dbContext.SaveChangesAsync();
        return item;
    }
}
