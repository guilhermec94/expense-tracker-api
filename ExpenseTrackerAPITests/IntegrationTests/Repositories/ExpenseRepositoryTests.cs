using ExpenseTrackerAPI.Model;
using ExpenseTrackerAPI.Repositories;
using ExpenseTrackerAPI.Utils;
using Microsoft.Extensions.Logging;
using Moq;

namespace ExpenseTrackerAPITests.IntegrationTests.Repositories
{
    [Collection("IntegrationTests collection")]
    public class ExpenseRepositoryTests
    {
        private IntegrationTestFixture Fixture;
        public ExpenseRepositoryTests(IntegrationTestFixture fixture) { Fixture = fixture; }

        [Fact]
        public async void GetAll_FetchAllRecords_ReturnExistingRecords()
        {
            // Arrange
            var provider = new IntegrationTestDatabaseProvider(Fixture.DatabaseConnectionString);
            var logger = new Mock<ILogger<ExpenseRepository>>();
            var ctx = await provider.CreateDbContextAsync();
            var repo = new ExpenseRepository(logger.Object, ctx);

            var category = new Category
            {
                ID = Guid.NewGuid(),
                Name = "Cat A",
            };

            List<BaseEntity> entities = new List<BaseEntity>
            {
                category
                ,
                new Category
                {
                    ID = Guid.NewGuid(),
                    Name = "Cat B",
                },
                new Expense
                {
                    ID = Guid.NewGuid(),
                    CategoryID =category.ID,
                    Date = DateTime.Now,
                    Description = "Test1",
                    Title = "Test1",
                },
                new Expense
                {
                    ID = Guid.NewGuid(),
                    CategoryID =category.ID,
                    Date = DateTime.Now,
                    Description = "Test2",
                    Title = "Test2",
                }
            };

            await provider.Seed(ctx, entities);

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
            var logger = new Mock<ILogger<ExpenseRepository>>();
            var ctx = await provider.CreateDbContextAsync();
            var repo = new ExpenseRepository(logger.Object, ctx);

            var category = new Category
            {
                ID = Guid.NewGuid(),
                Name = "Cat A",
            };

            List<BaseEntity> entities = new List<BaseEntity>
            {
                category,
                new Expense
                {
                    ID = Guid.NewGuid(),
                    CategoryID =category.ID,
                    Date = DateTime.Now,
                    Description = "Test1",
                    Title = "Test1",
                }
            };

            await provider.Seed(ctx, entities);

            // Act
            var (entity, status) = await repo.Get(entities[1].ID);

            // Assert
            Assert.Equal(entities[1].ID, entity.ID);
            Assert.Equal(RequestResultStatus.SUCCESS, status);
        }

        [Fact]
        public async void Add_CreateRecord_SaveNewRecord()
        {
            // Arrange
            var provider = new IntegrationTestDatabaseProvider(Fixture.DatabaseConnectionString);
            var logger = new Mock<ILogger<ExpenseRepository>>();
            var ctx = await provider.CreateDbContextAsync();
            var repo = new ExpenseRepository(logger.Object, ctx);

            var category = new Category
            {
                ID = Guid.NewGuid(),
                Name = "Cat A",
            };

            List<BaseEntity> entities = new List<BaseEntity>
            {
                category,
            };

            await provider.Seed(ctx, entities);

            var newExpense = new Expense
            {
                ID = Guid.NewGuid(),
                CategoryID = category.ID,
                Date = DateTime.Now,
                Description = "Test1",
                Title = "Test1",
            };

            // Act
            var (entity, status) = await repo.Create(newExpense);

            // Assert
            Assert.NotNull(entity);
            Assert.Equal(RequestResultStatus.SUCCESS, status);
        }

        [Fact]
        public async void Update_UpdateRecord_UpdateExstingRecord()
        {
            // Arrange
            var provider = new IntegrationTestDatabaseProvider(Fixture.DatabaseConnectionString);
            var logger = new Mock<ILogger<ExpenseRepository>>();
            var ctx = await provider.CreateDbContextAsync();
            var repo = new ExpenseRepository(logger.Object, ctx);

            var category = new Category
            {
                ID = Guid.NewGuid(),
                Name = "Cat A",
            };

            List<BaseEntity> entities = new List<BaseEntity>
            {
                category,
                new Expense
            {
                ID = Guid.NewGuid(),
                CategoryID = category.ID,
                Date = DateTime.Now,
                Description = "Test1",
                Title = "Test1",
            }
            };

            await provider.Seed(ctx, entities);

            // Act
            var status = await repo.Update((Expense)entities[1]);

            // Assert
            Assert.Equal(RequestResultStatus.SUCCESS, status);
        }

        [Fact]
        public async void Delete_DeleteRecord_DeleteExstingRecord()
        {
            // Arrange
            var provider = new IntegrationTestDatabaseProvider(Fixture.DatabaseConnectionString);
            var logger = new Mock<ILogger<ExpenseRepository>>();
            var ctx = await provider.CreateDbContextAsync();
            var repo = new ExpenseRepository(logger.Object, ctx);

            var category = new Category
            {
                ID = Guid.NewGuid(),
                Name = "Cat A",
            };

            List<BaseEntity> entities = new List<BaseEntity>
            {
                category,
                new Expense
            {
                ID = Guid.NewGuid(),
                CategoryID = category.ID,
                Date = DateTime.Now,
                Description = "Test1",
                Title = "Test1",
            }
            };

            await provider.Seed(ctx, entities);

            // Act
            var status = await repo.Delete(entities[1].ID);

            // Assert
            Assert.Equal(RequestResultStatus.SUCCESS, status);
        }
    }
}
