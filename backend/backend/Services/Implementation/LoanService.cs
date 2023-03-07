namespace Backend.Services;

using Backend.Models;
using Backend.DTOs;
using Backend.Db;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

public class LoanService : ILoanService
{
    private readonly AppDbContext _dbContext;
    public LoanService(AppDbContext dbContext) 
    {
        _dbContext = dbContext;
    }

    public async Task<ICollection<Loan>?> CreateAsync(MakeLoansDTO request)
    {
        var user = await _dbContext.Users.SingleOrDefaultAsync(user => user.Id == request.UserId);

        if (user is null)
        {
            return null;
        }

        var copies = await _dbContext.Copies
            .Where(copy => request.CopyIds.Contains(copy.Id))
            .ToListAsync();

        if (copies is null)
        {
            return null;
        }

        copies.ForEach(copy => copy.IsAvailable = false);

        IEnumerable<Loan> loans = copies
            .Select(copy => new Loan()
            {
                CopyId = copy.Id,
                UserId = user.Id,
                LoanedAt = DateTime.Now,
                DueDate = DateTime.Now.AddMonths(1)
            });

        _dbContext.AddRange(loans);
        await _dbContext.SaveChangesAsync();

        return loans.ToList();
    }

    public async Task<ICollection<Loan>> GetAllAsync(int page = 1, int pageSize = 50)
    {
        return await _dbContext.Loans
            .AsNoTracking()
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }

    public async Task<Loan?> GetByIdAsync(int id)
    {
        return await _dbContext.FindAsync<Loan>(id);
    }

    public async Task<ICollection<Loan>> GetExpiredLoansAsync(int page = 1, int pageSize = 50)
    {
        return await _dbContext.Loans
            .AsNoTracking()
            .Where(loan => loan.ShouldBeReturned)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }

    public async Task<ICollection<Loan>> GetLoansByUserAsync(int userId)
    {
        return await _dbContext.Loans
            .AsNoTracking()
            .Where(loan => loan.UserId == userId)
            .ToListAsync();
    }

    public async Task<ICollection<Loan>> GetOnGoingLoansAsync(int page = 1, int pageSize = 50)
    {
        return await _dbContext.Loans
            .AsNoTracking()
            .Where(loan => !loan.Returned)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }

    public async Task<Loan?> UpdateAsync(int id, UpdateLoanDTO request)
    {
        var loan = await _dbContext.Loans.SingleOrDefaultAsync(loan => loan.Id == id);
        
        if (loan == null)
        {
            return null;
        }
        if (request.Returned)
        {
            var copy = await _dbContext.Copies.SingleOrDefaultAsync(copy => copy.Id == loan.CopyId);
            if (copy is not  null)
            {
                copy.IsAvailable = true;
            }
        }

        request.UpdateModel(loan);
        await _dbContext.SaveChangesAsync();
        return loan;
    }
}
