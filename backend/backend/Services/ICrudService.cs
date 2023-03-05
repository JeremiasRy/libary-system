using Backend.DTOs;
using Backend.Models;

namespace Backend.Services;

public interface ICrudService<TModel, TDto> 
{
    public Task<ICollection<TModel>> GetAllAsync(int page = 1, int pageSize = 50);
    public Task<TModel?> GetByIdAsync(int id);
    public Task<TModel?> CreateAsync(TDto request);
    public Task<TModel?> UpdateAsync(int id, TDto request);
    public Task<bool> DeleteAsync(int id);
}
