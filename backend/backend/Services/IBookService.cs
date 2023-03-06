namespace Backend.Services;

using Backend.Models;
using Backend.DTOs;

public interface IBookService : ICrudService<Book, BookDTO>
{
    public Task<bool> AddCategoryToBook(int id, AddCategoryDTO request);
    public Task<bool> AddAuthorToBook(int id, AddAuthorDTO authorId);
    public Task<bool> AddPublisherToBook(int id, AddPublisherDTO addPublisherDTO);
    public Task<ICollection<Book>?> GetBooksByCategory(int categoryId, int page = 1, int pageSize = 50);
    public Task<ICollection<Book>?> GetBooksByAuthor(int authorId);
    public Task<ICollection<Book>?> GetBooksByPublisher(int publisherId, int page = 1, int pageSize = 50);
    public Task<ICollection<Book>?> GetByTitle(string searchTitle, int page = 1, int pageSie = 50);
}
