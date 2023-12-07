using ExpenseTracker.Domain.Common;
using ExpenseTracker.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.Tests.IntegrationTests
{
    public class IntegrationTestDatabaseProvider
    {
        private readonly string _connectionString;

        public IntegrationTestDatabaseProvider(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<ExpenseTrackerContext> CreateDbContextAsync()
        {
            var dbContextOptionsBuilder = new DbContextOptionsBuilder<ExpenseTrackerContext>();

            dbContextOptionsBuilder.UseNpgsql(this._connectionString).UseSnakeCaseNamingConvention();
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            var dbContext = new ExpenseTrackerContext(dbContextOptionsBuilder.Options);

            await dbContext.Database.MigrateAsync();

            return dbContext;
        }

        public async Task Seed(ExpenseTrackerContext dbContext, List<BaseEntity> data)
        {
            foreach (var entity in data)
            {
                dbContext.Add(entity);
                await dbContext.SaveChangesAsync();
            }

        }
    }
}
