namespace Backend.DTOs;

using Backend.Models;
public class UpdateLoanDTO : BaseDTO<Loan>
{
    public DateTime DueDate { get; set; }
    public bool Returned { get; set; }

    public override void UpdateModel(Loan model)
    {
        model.DueDate = DueDate;
        model.Returned = Returned;
    }
}
