namespace Backend.Services;

using Backend.Models;
using Backend.DTOs;
using Backend.Db;
using System.Threading.Tasks;

public class DbBookService : DbCrudService<Book, BookDTO>, IBookService
{
    public DbBookService(AppDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<bool> AddAuthorToBook(int id, AddAuthorDTO request)
    {
        var book = await _dbContext.FindAsync<Book>(id);
        var author = await _dbContext.FindAsync<Author>(request.AuthorId);

        if (book is null || author is null)
        {
            return false;
        }
        book.Authors.Add(author);
        await _dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> AddCategoryToBook(int id, AddCategoryDTO request)
    {
        var book = await _dbContext.FindAsync<Book>(id);
        var category = await _dbContext.FindAsync<Category>(request.CategoryId);
        if (book is null || category is null)
        {
            return false;
        }
        book.Categories.Add(category);
        await _dbContext.SaveChangesAsync();
        return true;
    }
}
