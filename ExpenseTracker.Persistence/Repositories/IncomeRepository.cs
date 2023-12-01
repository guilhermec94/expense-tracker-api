using ExpenseTracker.Domain.Abstractions;
using ExpenseTracker.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ExpenseTracker.Persistence.Repositories
{
    public class IncomeRepository : BaseRepository<Income, DbSet<Income>>, IIncomeRepository
    {
        public IncomeRepository(ILogger<IncomeRepository> logger, ExpenseTrackerContext ctx) : base(logger, ctx, ctx.Incomes)
        {
        }
    }
}
