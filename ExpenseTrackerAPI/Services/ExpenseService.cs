using AutoMapper;
using ExpenseTrackerAPI.CodeGen.Models;
using ExpenseTrackerAPI.Model;
using ExpenseTrackerAPI.Repositories;

namespace ExpenseTrackerAPI.Services
{
    public class ExpenseService : BaseService<Expense, ExpenseDTO>
    {
        public ExpenseService(IBaseRepository<Expense> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
