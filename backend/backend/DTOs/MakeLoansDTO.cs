using Backend.Models;

namespace Backend.DTOs;

public class MakeLoansDTO
{
    public int UserId { get; set; }
    public ICollection<int> CopyIds { get; set; } = null!;
}
