using DotNet.Testcontainers.Containers;
using Testcontainers.PostgreSql;

namespace ExpenseTracker.Tests.IntegrationTests
{
    public class IntegrationTestFixture : IAsyncLifetime
    {
        public readonly string DatabaseName = "expensetrackerdb";
        public readonly string Username = "expensetracker";
        public readonly string Password = "expensetracker";
        public string DatabaseConnectionString { get { return $"Host=localhost:5432;Database={DatabaseName};Username={Username};Password={Password}"; } }
        private static IContainer DbContainer { get; set; }

        public async Task InitializeAsync()
        {
            if (DbContainer is null)
            {
                DbContainer = new PostgreSqlBuilder()
                    .WithImage("postgres:15.1")
                    .WithPortBinding(5432)
                    .WithEnvironment("POSTGRES_DB", DatabaseName)
                    .WithEnvironment("POSTGRES_USER", Username)
                    .WithEnvironment("POSTGRES_PASSWORD", Password)
                    .WithCleanUp(true)
                    .Build();

                await DbContainer.StartAsync();
            }
        }

        public async Task DisposeAsync()
        {
            if (DbContainer is not null)
            {
                await DbContainer.StopAsync();
            }
        }
    }

    [CollectionDefinition("IntegrationTests collection")]
    public class IntegrationTestCollection : ICollectionFixture<IntegrationTestFixture>
    {
        // This class has no code, and is never created. Its purpose is simply
        // to be the place to apply [CollectionDefinition] and all the
        // ICollectionFixture<> interfaces.
    }
}
