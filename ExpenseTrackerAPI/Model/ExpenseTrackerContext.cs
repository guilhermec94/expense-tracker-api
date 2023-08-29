using Microsoft.EntityFrameworkCore;

namespace ExpenseTrackerAPI.Model
{
    public class ExpenseTrackerContext : DbContext
    {
        public ExpenseTrackerContext(DbContextOptions<ExpenseTrackerContext> options) : base(options) { }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Expense> Expenses { get; set; }
    }
}
