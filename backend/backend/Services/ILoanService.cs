namespace Backend.Services;

using Backend.Models;
using Backend.DTOs;
public interface ILoanService
{
    public Task<Loan?> GetByIdAsync(int id);
    public Task<ICollection<Loan>> GetAllAsync(int page = 1, int pageSize = 50);
    public Task<ICollection<Loan>?> CreateAsync(MakeLoansDTO request);
    public Task<Loan?> UpdateAsync(int id, UpdateLoanDTO request);
    public Task<ICollection<Loan>> GetExpiredLoansAsync(int page = 1, int pageSize = 50);
    public Task<ICollection<Loan>> GetOnGoingLoansAsync(int page = 1, int pageSize = 50);
    public Task<ICollection<Loan>> GetLoansByUserAsync(int userId);
}
