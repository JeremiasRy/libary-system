namespace Backend.Services;

using Backend.Models;
using Backend.DTOs;
using Backend.Db;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

public class DbCartItemService : DbCrudService<CartItem, CartItemDTO>, ICartItemService
{
    public DbCartItemService(AppDbContext dbContext) : base(dbContext)
    {
    }
    public override async Task<CartItem?> CreateAsync(CartItemDTO request)
    {
        var user = await _dbContext.Set<User>().FindAsync(request.UserId);
        var copy = await _dbContext.Set<Copy>().FindAsync(request.CopyId);

        if (user is null || copy is null)
        {
            return null;
        }

        var cartItem = new CartItem();
        request.UpdateModel(cartItem);
        _dbContext.Add(cartItem);
        await _dbContext.SaveChangesAsync();

        return cartItem;
    }

    public async Task<ICollection<CartItem>> GetCartByUserId(int userId)
    {
        return await _dbContext
            .Set<CartItem>()
            .Where(cartItem => cartItem.UserId == userId)
            .ToListAsync();
    }
}
