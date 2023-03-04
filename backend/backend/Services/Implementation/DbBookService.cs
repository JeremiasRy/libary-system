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

    public override async Task<ICollection<Book>> GetAllAsync()
    {
        return await _dbContext
            .Set<Book>()
            .Include(book => book.BookCategoryLinks)
                .ThenInclude(bc => bc.Category)
            .Include(book => book.BookAuthorLinks)
                .ThenInclude(ba => ba.Author)
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
        if (book == null)
        {
            return false;
        }
        book.BookAuthorLinks.Add(new BookAuthor() { BookId = id, AuthorId = request.AuthorId });
        await _dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> AddCategoryToBook(int id, AddCategoryDTO request)
    {
        var book = await _dbContext.FindAsync<Book>(id);
        if (book == null)
        {
            return false;
        }
        book.BookCategoryLinks.Add(new BookCategory() { BookId = id, CategoryId = request.CategoryId });
        await _dbContext.SaveChangesAsync();
        return true;
    }
}
