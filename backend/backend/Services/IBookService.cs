namespace Backend.Services;

using Backend.Models;
using Backend.DTOs;

public interface IBookService : ICrudService<Book, BookDTO>
{
    public Task<bool> AddCategoryToBook(int id, AddCategoryDTO request);
    public Task<bool> AddAuthorToBook(int id, AddAuthorDTO authorId);
}
