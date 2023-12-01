
using DotNet.Testcontainers.Builders;
using DotNet.Testcontainers.Containers;
using ExpenseTracker.Domain.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Testcontainers.PostgreSql;

namespace ExpenseTracker.APITests.Factory
{
    public class IntegrationTestWebApiFactory : WebApplicationFactory<Program>, IAsyncLifetime
    {
        private readonly IContainer _dbContainer = new PostgreSqlBuilder()
            .WithImage("postgres:15.1")
            .WithPortBinding(5432)
            .WithEnvironment("POSTGRES_DB", "test")
            .WithEnvironment("POSTGRES_USER", "user")
            .WithEnvironment("POSTGRES_PASSWORD", "pass")
            .WithCommand("-c", "fsync=off")
            .WithCommand("-c", "full_page_writes=off")
            .WithCommand("-c", "synchronous_commit=off")
            .WithWaitStrategy(Wait.ForUnixContainer())
            .Build();

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureTestServices(service =>
            {
                var descriptorType = typeof(DbContextOptions<ExpenseTrackerContext>);

                var descriptor = service.SingleOrDefault(s => s.ServiceType == descriptorType);

                if (descriptor is not null)
                {
                    service.Remove(descriptor);
                }

                var connectionString = _dbContainer.Hostname;
                service.AddDbContext<ExpenseTrackerContext>(options => options
                .UseNpgsql(connectionString)
                .UseSnakeCaseNamingConvention());
            });
        }
        public Task InitializeAsync()
        {
            return _dbContainer.StartAsync();
        }

        Task IAsyncLifetime.DisposeAsync()
        {
            return _dbContainer.StopAsync();
        }
    }
}
