using ExpenseTrackerAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTrackerAPI.Repositories
{
    public interface ICategoryRepository : IBaseRepository<Category> { }
    public class CategoryRepository : BaseRepository<Category, DbSet<Category>>, ICategoryRepository
    {
        public CategoryRepository(ILogger<CategoryRepository> logger, ExpenseTrackerContext ctx) : base(logger, ctx, ctx.Categories)
        {
        }
    }
}
