using ExpenseTrackerAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTrackerAPI.Repositories
{
    public class ExpenseRepository : BaseRepository<Expense, DbSet<Expense>>
    {
        public ExpenseRepository(ILogger logger, ExpenseTrackerContext ctx, DbSet<Expense> dbSet) : base(logger, ctx, dbSet)
        {
        }
    }
}
