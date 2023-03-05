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

}
