using AutoMapper;
using ExpenseTrackerAPI.CodeGen.Models;
using ExpenseTrackerAPI.Model;
using ExpenseTrackerAPI.Repositories;
using ExpenseTrackerAPI.Utils;

namespace ExpenseTrackerAPI.Services
{
    public interface IExpenseService : IBaseService<ExpenseDTO>
    {
        Task<(ExpenseDTO dto, RequestResultStatus status)> Create(CreateExpenseDTO dto);
        Task<RequestResultStatus> Update(Guid id, UpdateExpenseDTO dto);
    }
    public class ExpenseService : BaseService<Expense, ExpenseDTO>, IExpenseService
    {
        public ExpenseService(IExpenseRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }

        public async Task<(ExpenseDTO dto, RequestResultStatus status)> Create(CreateExpenseDTO dto)
        {
            var entity = base._mapper.Map<ExpenseDTO>(dto);
            return await base.Create(entity);
        }

        public async Task<RequestResultStatus> Update(Guid id, UpdateExpenseDTO dto)
        {
            var entity = base._mapper.Map<ExpenseDTO>(dto);
            return await base.Update(id, entity);
        }
    }
}
