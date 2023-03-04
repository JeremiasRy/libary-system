namespace backend.Services;

using backend.Models;
using backend.DTOs;

public interface IBookService : ICrudService<Book, BookDTO>
{
    public Task<bool> AddCategoryToBook(int id, AddCategoryDTO request);
    public Task<bool> AddAuthorToBook(int id, AddAuthorDTO authorId);
}
