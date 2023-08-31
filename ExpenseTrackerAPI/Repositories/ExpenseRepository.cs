using ExpenseTrackerAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTrackerAPI.Repositories
{
    public interface IExpenseRepository : IBaseRepository<Expense> { }
    public class ExpenseRepository : BaseRepository<Expense, DbSet<Expense>>, IExpenseRepository
    {
        public ExpenseRepository(ILogger<ExpenseRepository> logger, ExpenseTrackerContext ctx) : base(logger, ctx, ctx.Expenses)
        {
        }
    }
}
