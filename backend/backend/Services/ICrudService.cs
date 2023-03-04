using backend.DTOs;
using backend.Models;

namespace backend.Services;

public interface ICrudService<TModel, TDto> 
{
    public Task<ICollection<TModel>> GetAllAsync();
    public Task<TModel?> GetByIdAsync(int id);
    public Task<TModel?> CreateAsync(TDto request);
    public Task<TModel?> UpdateAsync(int id, TDto request);
    public Task<bool> DeleteAsync(int id);
}
