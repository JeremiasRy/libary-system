namespace Backend.Controllers;

using Backend.Models;
using Backend.DTOs;
using Backend.Services;
using Microsoft.AspNetCore.Mvc;

public class BookController : CrudController<Book, BookDTO>
{
    private readonly IBookService _bookService;
    public BookController(IBookService bookService) : base(bookService)
    {
        _bookService = bookService;
    }
    [HttpGet("filter")]
    public async Task<ICollection<Book>?> GetBooksByFilter([FromQuery] int? category, [FromQuery] int? publisher, [FromQuery] string? title)
    {
        if (category is not null)
        {
            return await _bookService.GetBooksByCategory((int)category);
        }
        if (publisher is not null)
        {
            return await _bookService.GetBooksByPublisher((int)publisher);
        }
        if (title is not null)
        {
            return await _bookService.GetByTitle(title);
        }
        return await base.GetAll();
    }
    [HttpPost("{id:int}/categories")]
    public async Task<bool> AddCategoryToBook([FromRoute] int id, [FromBody] AddCategoryDTO request)
    {
        return await _bookService.AddCategoryToBook(id, request);
    }
    [HttpPost("{id:int}/authors")]
    public async Task<bool> AddAuthorToBook([FromRoute] int id, [FromBody] AddAuthorDTO request)
    {
        return await _bookService.AddAuthorToBook(id, request);
    }
    [HttpPost("{id:int}/publishers")]
    public async Task<bool> AddPublisherToBook([FromRoute] int id, [FromBody] AddPublisherDTO request)
    {
        return await _bookService.AddPublisherToBook(id, request);
    }

}
