using ExpenseTrackerAPI.CodeGen.Models;
using ExpenseTrackerAPI.Services;

namespace ExpenseTrackerAPI.Handlers
{
    public interface IExpenseHandler : IBaseHandler<ExpenseDTO>
    {

    }

    public class ExpenseHandler : BaseHandler<ExpenseDTO>, IExpenseHandler
    {
        public ExpenseHandler(IBaseService<ExpenseDTO> service) : base(service)
        {
        }
    }
}
