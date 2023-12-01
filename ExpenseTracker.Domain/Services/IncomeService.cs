using AutoMapper;
using ExpenseTracker.CodeGen.Models;
using ExpenseTracker.Domain.Abstractions;
using ExpenseTracker.Domain.Entities;
using ExpenseTracker.SharedKernel.Utils;

namespace ExpenseTracker.Domain.Services
{
    public class IncomeService : BaseService<Income, IncomeDTO>, IIncomeService
    {
        public IncomeService(IIncomeRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }

        public async Task<(IncomeDTO dto, RequestResultStatus status)> Create(CreateIncomeDTO dto)
        {
            var entity = base._mapper.Map<IncomeDTO>(dto);
            return await base.Create(entity);
        }

        public async Task<RequestResultStatus> Update(Guid id, UpdateIncomeDTO dto)
        {
            var entity = base._mapper.Map<IncomeDTO>(dto);
            return await base.Update(id, entity);
        }
    }
}
