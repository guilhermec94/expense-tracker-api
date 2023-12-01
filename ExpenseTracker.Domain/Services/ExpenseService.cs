using AutoMapper;
using ExpenseTracker.CodeGen.Models;
using ExpenseTracker.Domain.Abstractions;
using ExpenseTracker.Domain.Entities;
using ExpenseTracker.SharedKernel.Utils;

namespace ExpenseTracker.Domain.Services
{
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
