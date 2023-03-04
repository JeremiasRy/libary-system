namespace backend.Services;

using backend.Models;
using backend.DTOs;
public interface ILoanService : ICrudService<Loan, LoanDTO>
{
    public Task<ICollection<Loan>> GetExpiredLoansAsync();
    public Task<ICollection<Loan>> GetOnGoingLoansAsync();
    public Task<ICollection<Loan>> GetLoansByUserAsync(int userId);
}
