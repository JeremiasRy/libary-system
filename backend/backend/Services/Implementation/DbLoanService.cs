namespace backend.Services;

using backend.Models;
using backend.DTOs;
using backend.Db;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

public class DbLoanService : DbCrudService<Loan, LoanDTO>, ILoanService
{
    public DbLoanService(AppDbContext dbContext) : base(dbContext)
    {
    }
    public override async Task<Loan?> CreateAsync(LoanDTO request)
    {
        var user = _dbContext.Find<User>(request.UserId);
        if (user == null)
        {
            return null;
        }
        var loan = new Loan()
        {
            LoanedAt = DateTime.Now,
            DueDate = DateTime.Now.AddMonths(1),

        };
        request.UpdateModel(loan);
        _dbContext.Add(loan);
        await _dbContext.SaveChangesAsync();
        return loan;
    }

    public async Task<ICollection<Loan>> GetExpiredLoansAsync()
    {
        var loans = await GetAllAsync();

        return loans
            .Where(loan => loan.ShouldBeReturned)
            .ToList();
    }

    public async Task<ICollection<Loan>> GetLoansByUserAsync(int userId)
    {
        var loans = await GetAllAsync();

        return loans
            .Where(loan => loan.User.Id == userId)
            .ToList();
    }

    public async Task<ICollection<Loan>> GetOnGoingLoansAsync()
    {
        var loans = await GetAllAsync();

        return loans
            .Where(loan => !loan.Returned)
            .ToList();
    }
}
