namespace Backend.Services;

using Backend.Models;
using Backend.DTOs;
public interface ILoanService : ICrudService<Loan, LoanDTO>
{
    public Task<ICollection<Loan>> GetExpiredLoansAsync();
    public Task<ICollection<Loan>> GetOnGoingLoansAsync();
    public Task<ICollection<Loan>> GetLoansByUserAsync(int userId);
}
