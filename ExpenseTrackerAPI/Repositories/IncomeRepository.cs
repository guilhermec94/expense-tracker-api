using ExpenseTrackerAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTrackerAPI.Repositories
{
    public interface IIncomeRepository : IBaseRepository<Income> { }
    public class IncomeRepository : BaseRepository<Income, DbSet<Income>>, IIncomeRepository
    {
        public IncomeRepository(ILogger<IncomeRepository> logger, ExpenseTrackerContext ctx) : base(logger, ctx, ctx.Incomes)
        {
        }
    }
}
