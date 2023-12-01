using ExpenseTracker.Domain.Abstractions;
using ExpenseTracker.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ExpenseTracker.Persistence.Repositories
{
    public class CategoryRepository : BaseRepository<Category, DbSet<Category>>, ICategoryRepository
    {
        public CategoryRepository(ILogger<CategoryRepository> logger, ExpenseTrackerContext ctx) : base(logger, ctx, ctx.Categories)
        {
        }
    }
}
