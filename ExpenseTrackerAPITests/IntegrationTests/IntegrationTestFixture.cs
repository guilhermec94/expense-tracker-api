using DotNet.Testcontainers.Builders;
using DotNet.Testcontainers.Containers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testcontainers.PostgreSql;

namespace ExpenseTrackerAPITests.IntegrationTests
{
    public class IntegrationTestFixture : IAsyncLifetime
    {
        public static string DatabaseName = "expensetrackerdb";
        public static string Username = "expensetracker";
        public static string Password = "expensetracker";
        public static string DatabaseConnectionString => $"Host=localhost:5432;Database={DatabaseName};Username={Username};Password={Password}";
        private static IContainer _dbContainer { get; set; }

        public async Task InitializeAsync()
        {
            if (_dbContainer is null)
            {
                _dbContainer = new PostgreSqlBuilder()
                    .WithImage("postgres:15.1")
                    .WithPortBinding(5432)
                    .WithEnvironment("POSTGRES_DB", DatabaseName)
                    .WithEnvironment("POSTGRES_USER", Username)
                    .WithEnvironment("POSTGRES_PASSWORD", Password)
                    .WithCommand("-c", "fsync=off")
                    .WithCommand("-c", "full_page_writes=off")
                    .WithCommand("-c", "synchronous_commit=off")
                    .WithWaitStrategy(Wait.ForUnixContainer())
                    .WithCleanUp(true)
                    .Build();

                await _dbContainer.StartAsync();
            }
        }

        public async Task DisposeAsync()
        {
            if (_dbContainer is not null)
            {
                await _dbContainer.StopAsync();
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
