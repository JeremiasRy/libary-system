using Backend.Models;

namespace Backend.DTOs;

public class LoanDTO : BaseDTO<Loan>
{
    public int UserId { get; set; }
    public int CopyId { get; set;}
    public override void UpdateModel(Loan model)
    {
        model.UserId = UserId;
        model.CopyId = CopyId;
    }
}
