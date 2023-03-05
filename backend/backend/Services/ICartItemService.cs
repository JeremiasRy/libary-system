namespace Backend.Services;

using Backend.Models;
using Backend.DTOs;
public interface ICartItemService : ICrudService<CartItem, CartItemDTO>
{
    public Task<ICollection<CartItem>> GetCartByUserId(int userId);
}
