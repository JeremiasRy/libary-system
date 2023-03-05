namespace backend.Services;

using backend.Models;
using backend.DTOs;
public interface ICartItemService : ICrudService<CartItem, CartItemDTO>
{
    public Task<ICollection<CartItem>> GetCartByUserId(int userId);
}
