namespace backend.Services;

using backend.Models;
using backend.DTOs;
using backend.Db;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

public class DbBookService : DbCrudService<Book, BookDTO>, IBookService
{
    public DbBookService(AppDbContext dbContext) : base(dbContext)
    {
    }

    public override async Task<ICollection<Book>> GetAllAsync(int page = 1, int pageSize = 50)
    {
        return await _dbContext
            .Set<Book>()
            .AsNoTracking()
            .Include(book => book.Categories)
            .Include(book => book.Authors)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }
    public override async Task<Book?> GetByIdAsync(int id)
    {
        var books = await GetAllAsync();
        return books.FirstOrDefault(book => book.Id == id);
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
