using ExpenseTracker.Domain.Abstractions;
using ExpenseTracker.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ExpenseTracker.Persistence.Repositories
{
    public class ExpenseRepository : BaseRepository<Expense, DbSet<Expense>>, IExpenseRepository
    {
        public ExpenseRepository(ILogger<ExpenseRepository> logger, ExpenseTrackerContext ctx) : base(logger, ctx, ctx.Expenses)
        {
        }
    }
}
