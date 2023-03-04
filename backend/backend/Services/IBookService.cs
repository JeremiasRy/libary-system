namespace backend.Services;

using backend.Models;
using backend.DTOs;

public interface IBookService : ICrudService<Book, BookDTO>
{
    public Task<bool> AddCategoryToBook(int bookId, int categoryId);
    public Task<bool> AddAuthorToBook(int bookId, int authorId);
}
