using AutoMapper;
using ExpenseTrackerAPI.CodeGen.Models;
using ExpenseTrackerAPI.Model;
using ExpenseTrackerAPI.Repositories;
using ExpenseTrackerAPI.Utils;

namespace ExpenseTrackerAPI.Services
{
    public interface IIncomeService : IBaseService<IncomeDTO>
    {
        Task<(IncomeDTO dto, RequestResultStatus status)> Create(CreateIncomeDTO dto);
        Task<RequestResultStatus> Update(Guid id, UpdateIncomeDTO dto);
    }
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
