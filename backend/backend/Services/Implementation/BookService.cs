namespace Backend.Services;

using Backend.Models;
using Backend.DTOs;
using Backend.Db;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

public class BookService : DbCrudService<Book, BookDTO>, IBookService
{
    public BookService(AppDbContext dbContext) : base(dbContext)
    {
    }
    public async Task<ICollection<Book>?> GetByTitle(string searchTitle, int page = 1, int pageSize = 50)
    {
        return await _dbContext.Books
            .Where(book => book.Title.ToLower().Contains(searchTitle.ToLower()))
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }
    public async Task<bool> AddAuthorToBook(int id, AddDTO request)
    {
        var book = await _dbContext.Books.SingleOrDefaultAsync(book => book.Id == id);
        var author = await _dbContext.Authors.SingleOrDefaultAsync(author => author.Id == request.AddId);

        if (book is null || author is null)
        {
            return false;
        }

        book.Authors.Add(author);
        await _dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> AddCategoryToBook(int id, AddDTO request)
    {
        var book = await _dbContext.Books.SingleOrDefaultAsync(book => book.Id == id);
        var category = await _dbContext.Categories.SingleOrDefaultAsync(category => category.Id == request.AddId);

        if (book is null || category is null)
        {
            return false;
        }

        book.Categories.Add(category);
        await _dbContext.SaveChangesAsync();
        return true;
    }
    public async Task<bool> AddPublisherToBook(int id, AddDTO request)
    {
        var book = await _dbContext.Books.SingleOrDefaultAsync(book => book.Id == id);
        var publisher = await _dbContext.Publishers.SingleOrDefaultAsync(publisher => publisher.Id == request.AddId);

        if (book is null || publisher is null)
        {
            return false;
        }

        book.Publishers.Add(publisher);
        await _dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<ICollection<Book>?> GetBooksByAuthor(int authorId)
    {
        return await _dbContext.Books
            .AsNoTracking()
            .Where(book => book.Authors.Select(author => author.Id).Contains(authorId))
            .ToListAsync();
    }

    public async Task<ICollection<Book>?> GetBooksByCategory(int categoryId, int page = 1, int pageSize = 50)
    {
        return await _dbContext.Books
            .AsNoTracking()
            .Where(book => book.Categories.Select(category => category.Id).Contains(categoryId))
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }

    public async Task<ICollection<Book>?> GetBooksByPublisher(int publisherId, int page = 1, int pageSize = 50)
    {
        return await _dbContext.Books
            .AsNoTracking()
            .Where(book => book.Publishers.Select(publisher => publisher.Id).Contains(publisherId))
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }
}
