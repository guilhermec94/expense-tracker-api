using ExpenseTrackerAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTrackerAPI.Repositories
{
    public class CategoryRepository : BaseRepository<Category, DbSet<Category>>
    {
        public CategoryRepository(ILogger logger, ExpenseTrackerContext ctx, DbSet<Category> dbSet) : base(logger, ctx, dbSet)
        {
        }
    }
}
