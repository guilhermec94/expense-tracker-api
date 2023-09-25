using ExpenseTrackerAPI.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrackerAPITests.IntegrationTests
{
    public class IntegrationTestDatabaseProvider
    {
        private readonly string _connectionString;

        public IntegrationTestDatabaseProvider(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<IntegrationTestDatabaseProvider> Build()
        {
            var dbContext = this.CreateDbContext();

            await dbContext.Database.MigrateAsync();

            var provider = new IntegrationTestDatabaseProvider(this._connectionString);

            await provider.Seed();

            return provider;
        }

        private async Task Seed()
        {
            await using var dbContext = this.CreateDbContext();

            dbContext.Categories.Add(new Category
            {
                ID = Guid.NewGuid(),
                Name = "Cat A",
            });

            await dbContext.SaveChangesAsync();
        }

        private ExpenseTrackerContext CreateDbContext()
        {
            var dbContextOptionsBuilder = new DbContextOptionsBuilder<ExpenseTrackerContext>();

            dbContextOptionsBuilder.UseNpgsql(this._connectionString).UseSnakeCaseNamingConvention();

            var dbContext = new ExpenseTrackerContext(dbContextOptionsBuilder.Options);

            return dbContext;
        }
    }
}
