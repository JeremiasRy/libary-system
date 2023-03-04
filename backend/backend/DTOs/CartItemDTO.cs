namespace backend.DTOs;

using backend.Models;
public class CartItemDTO : BaseDTO<CartItem>
{
    public int CopyId { get; set; }
    public int UserId { get; set; }
    public override void UpdateModel(CartItem model)
    {
        model.CopyId = CopyId;
        model.UserId = UserId;
    }
}
