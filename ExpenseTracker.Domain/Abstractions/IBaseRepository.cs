using ExpenseTracker.Domain.Common;
using ExpenseTracker.SharedKernel.Utils;

namespace ExpenseTracker.Domain.Abstractions
{
    public interface IBaseRepository<I> where I : BaseEntity
    {
        (IEnumerable<I> data, int count) GetAll(int? offset, int? limit);
        Task<(I entity, RequestResultStatus status)> Get(Guid id);
        Task<(I entity, RequestResultStatus status)> Create(I entity);
        Task<RequestResultStatus> Update(I entity);
        Task<RequestResultStatus> Delete(Guid id);
    }
}
