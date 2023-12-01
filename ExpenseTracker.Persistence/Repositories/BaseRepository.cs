using ExpenseTracker.Domain.Abstractions;
using ExpenseTracker.Domain.Common;
using ExpenseTracker.Domain.Entities;
using ExpenseTracker.SharedKernel.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ExpenseTracker.Persistence.Repositories
{
    public abstract class BaseRepository<I, T> : IBaseRepository<I> where I : BaseEntity where T : DbSet<I>
    {
        private readonly ILogger _logger;
        protected readonly ExpenseTrackerContext Ctx;
        protected readonly T DbSet;
        public BaseRepository(ILogger logger, ExpenseTrackerContext ctx, T dbSet)
        {
            _logger = logger;
            Ctx = ctx;
            DbSet = dbSet;
        }

        public (IEnumerable<I> data, int count) GetAll(int? offset, int? limit)
        {
            var query = DbSet.Skip(offset.Value).Take(limit.Value);
            return (query, query.Count());
        }

        public async Task<(I entity, RequestResultStatus status)> Get(Guid id)
        {
            var res = await DbSet.AsNoTracking().Where(x => x.ID == id).FirstOrDefaultAsync();
            if (res == null)
            {
                return (res, RequestResultStatus.NOT_FOUND);
            }
            return (res, RequestResultStatus.SUCCESS);
        }

        public async Task<(I entity, RequestResultStatus status)> Create(I entity)
        {
            try
            {
                await DbSet.AddAsync(entity);
                await Ctx.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                var msg = $"{nameof(T)} error creating, aborting!";
                _logger.LogWarning(msg, ex);
                return (entity, RequestResultStatus.ERROR);
            }

            return (entity, RequestResultStatus.SUCCESS);
        }

        public async Task<RequestResultStatus> Update(I entity)
        {
            try
            {
                DbSet.Update(entity);
                await Ctx.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                var current = await DbSet.FindAsync(entity.ID);
                var msg = $"{nameof(T)} error updating, aborting!";
                _logger.LogWarning(msg, ex);
                return RequestResultStatus.ERROR;
            }

            return RequestResultStatus.SUCCESS;
        }

        public async Task<RequestResultStatus> Delete(Guid id)
        {
            var entity = await DbSet.FindAsync(id);
            if (entity == null)
            {
                var msg = $"{nameof(T)} with ID {id} does not exists!";
                _logger.LogWarning(msg);
                return RequestResultStatus.NOT_FOUND;
            }

            DbSet.Remove(entity);

            try
            {
                await Ctx.SaveChangesAsync();
                return RequestResultStatus.SUCCESS;
            }
            catch (Exception ex)
            {
                var msg = $"{nameof(T)} error deleting, aborting!";
                _logger.LogWarning(msg, ex);
                return RequestResultStatus.ERROR;
            }
        }
    }
}
