namespace backend.Models;

public class CartItem
{
    public Copy Copy { get; set; } = null!;
    public User User { get; set; } = null!;

    public int CopyId { get; set; }
    public int UserId { get; set; }

}
