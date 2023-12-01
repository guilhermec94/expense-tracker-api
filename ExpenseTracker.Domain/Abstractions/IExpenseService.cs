using ExpenseTracker.CodeGen.Models;
using ExpenseTracker.SharedKernel.Utils;

namespace ExpenseTracker.Domain.Abstractions
{
    public interface IExpenseService : IBaseService<ExpenseDTO>
    {
        Task<(ExpenseDTO dto, RequestResultStatus status)> Create(CreateExpenseDTO dto);
        Task<RequestResultStatus> Update(Guid id, UpdateExpenseDTO dto);
    }
}
