using ExpenseTracker.CodeGen.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTracker.Application.Abstractions
{
    public interface IIncomeService : IBaseService<IncomeDTO>
    {
        Task<IActionResult> Add(CreateIncomeDTO dto);
        Task<IActionResult> Update(Guid id, UpdateIncomeDTO dto);
    }
}
