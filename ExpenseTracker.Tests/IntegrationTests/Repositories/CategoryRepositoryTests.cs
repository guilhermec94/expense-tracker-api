using ExpenseTracker.Domain.Common;
using ExpenseTracker.Domain.Entities;
using ExpenseTracker.Persistence.Repositories;
using ExpenseTracker.SharedKernel.Utils;
using Microsoft.Extensions.Logging;
using Moq;
using Newtonsoft.Json;

namespace ExpenseTracker.Tests.IntegrationTests.Repositories
{
    [Collection("IntegrationTests collection")]
    public class CategoryRepositoryTests
    {
        private IntegrationTestFixture Fixture { get; }
        public CategoryRepositoryTests(IntegrationTestFixture fixture)
        {
            Fixture = fixture;
        }

        [Fact]
        public async void GetAll_FetchAllRecords_ReturnExistingRecords()
        {
            // Arrange
            var provider = new IntegrationTestDatabaseProvider(Fixture.DatabaseConnectionString);
            var logger = new Mock<ILogger<CategoryRepository>>();
            var ctx = await provider.CreateDbContextAsync();
            var repo = new CategoryRepository(logger.Object, ctx);

            List<BaseEntity> entities = new List<BaseEntity>
            {
                new Category
                {
                    ID = Guid.NewGuid(),
                    Name = "Cat A",
                },
                new Category
                {
                    ID = Guid.NewGuid(),
                    Name = "Cat B",
                }
            };

            await provider.Seed(ctx, entities);

            // Act
            var (data, count) = repo.GetAll(0, 10);

            // Assert
            Assert.Equal(entities, data);
            Assert.Equal(2, count);
        }

        [Fact]
        public async void Get_FetchRecord_ReturnExistingRecord()
        {
            // Arrange
            var provider = new IntegrationTestDatabaseProvider(Fixture.DatabaseConnectionString);
            var logger = new Mock<ILogger<CategoryRepository>>();
            var ctx = await provider.CreateDbContextAsync();
            var repo = new CategoryRepository(logger.Object, ctx);

            List<BaseEntity> entities = new List<BaseEntity>
            {
                new Category
                {
                    ID = Guid.NewGuid(),
                    Name = "Cat A",
                }
            };

            await provider.Seed(ctx, entities);

            // Act
            var (entity, status) = await repo.Get(entities[0].ID);

            // Assert
            Assert.Equal(JsonConvert.SerializeObject(entities[0]), JsonConvert.SerializeObject(entity));
            Assert.Equal(RequestResultStatus.SUCCESS, status);
        }

        [Fact]
        public async void Add_CreateRecord_SaveNewRecord()
        {
            // Arrange
            var provider = new IntegrationTestDatabaseProvider(Fixture.DatabaseConnectionString);
            var logger = new Mock<ILogger<CategoryRepository>>();
            var ctx = await provider.CreateDbContextAsync();
            var repo = new CategoryRepository(logger.Object, ctx);

            var newCategory = new Category
            {
                ID = Guid.NewGuid(),
                Name = "Cat A",
            };

            // Act
            var (entity, status) = await repo.Create(newCategory);

            // Assert
            Assert.NotNull(entity);
            Assert.Equal(RequestResultStatus.SUCCESS, status);
        }

        [Fact]
        public async void Update_UpdateRecord_UpdateExstingRecord()
        {
            // Arrange
            var provider = new IntegrationTestDatabaseProvider(Fixture.DatabaseConnectionString);
            var logger = new Mock<ILogger<CategoryRepository>>();
            var ctx = await provider.CreateDbContextAsync();
            var repo = new CategoryRepository(logger.Object, ctx);

            List<BaseEntity> entities = new List<BaseEntity>
            {
                new Category
                {
                    ID = Guid.NewGuid(),
                    Name = "Cat A",
                }
            };

            await provider.Seed(ctx, entities);

            // Act
            var status = await repo.Update((Category)entities[0]);

            // Assert
            Assert.Equal(RequestResultStatus.SUCCESS, status);
        }

        [Fact]
        public async void Delete_DeleteRecord_DeleteExstingRecord()
        {
            // Arrange
            var provider = new IntegrationTestDatabaseProvider(Fixture.DatabaseConnectionString);
            var logger = new Mock<ILogger<CategoryRepository>>();
            var ctx = await provider.CreateDbContextAsync();
            var repo = new CategoryRepository(logger.Object, ctx);

            List<BaseEntity> entities = new List<BaseEntity>
            {
                new Category
                {
                    ID = Guid.NewGuid(),
                    Name = "Cat A",
                }
            };

            await provider.Seed(ctx, entities);

            // Act
            var status = await repo.Delete(entities[0].ID);

            // Assert
            Assert.Equal(RequestResultStatus.SUCCESS, status);
        }
    }
}
