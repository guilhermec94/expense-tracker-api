using ExpenseTracker.CodeGen.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTracker.Application.Abstractions
{
    public interface IExpenseService : IBaseService<ExpenseDTO>
    {
        Task<IActionResult> Add(CreateExpenseDTO dto);
        Task<IActionResult> Update(Guid id, UpdateExpenseDTO dto);
    }
}
