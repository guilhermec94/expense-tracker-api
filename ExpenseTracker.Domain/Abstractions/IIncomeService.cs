using ExpenseTracker.CodeGen.Models;
using ExpenseTracker.SharedKernel.Utils;

namespace ExpenseTracker.Domain.Abstractions
{
    public interface IIncomeService : IBaseService<IncomeDTO>
    {
        Task<(IncomeDTO dto, RequestResultStatus status)> Create(CreateIncomeDTO dto);
        Task<RequestResultStatus> Update(Guid id, UpdateIncomeDTO dto);
    }
}
