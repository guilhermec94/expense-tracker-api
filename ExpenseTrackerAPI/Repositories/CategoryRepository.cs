using ExpenseTrackerAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTrackerAPI.Repositories
{
    public class CategoryRepository : BaseRepository<Category, DbSet<Category>>
    {
        public CategoryRepository(ILogger<CategoryRepository> logger, ExpenseTrackerContext ctx) : base(logger, ctx, ctx.Categories)
        {
        }
    }
}
