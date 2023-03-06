namespace Backend.Controllers;

using Microsoft.AspNetCore.Mvc;
using Backend.Models;
using Backend.DTOs;
using Backend.Services;

public class LoanController : ApiBaseController
{
    private readonly ILoanService _loanService;
    public LoanController(ILoanService loanService) => _loanService = loanService;
    
    [HttpGet]
    public async Task<ICollection<Loan>> GetAll([FromQuery] FilterOptions? filter, [FromQuery] int page = 1, [FromQuery] int pageSize = 50)
    {
        if (filter is not null)
        {
            return filter == FilterOptions.Expired 
                ? await _loanService.GetExpiredLoansAsync(page, pageSize) 
                : await _loanService.GetOnGoingLoansAsync(page, pageSize);
        }
        return await _loanService.GetAllAsync(page, pageSize);
    }
    [HttpGet("{id:int}")]
    public async Task<Loan?> Get([FromRoute] int id)
    {
        return await _loanService.GetByIdAsync(id);
    }
    [HttpGet("user/{id:int}")]
    public async Task<ICollection<Loan>?> GetByUser([FromRoute] int id)
    {
        return await _loanService.GetLoansByUserAsync(id);
    }
    [HttpPost]
    public async Task<ICollection<Loan>?> MakeLoans([FromBody] MakeLoansDTO request)
    {
        return await _loanService.CreateAsync(request);
    }
    [HttpPut("{id:int}")]
    public async Task<Loan?> UpdateLoan([FromRoute] int id, [FromBody] UpdateLoanDTO request)
    {
        return await _loanService.UpdateAsync(id, request);
    }
    public enum FilterOptions
    {
        Expired,
        OnGoing
    }
}
