using ExpenseTracker.CodeGen.Models;
using ExpenseTracker.SharedKernel.Utils;

namespace ExpenseTracker.Domain.Abstractions
{
    public interface IBaseService<D> where D : class
    {
        Task<(IEnumerable<D> data, PaginationDTO pagination)> GetAll(int? offset, int? limit);
        public Task<(D dto, RequestResultStatus status)> Get(Guid id);
        public Task<(D dto, RequestResultStatus status)> Create(D dto);
        public Task<RequestResultStatus> Update(Guid id, D dto);
        public Task<RequestResultStatus> Delete(Guid id);
    }
}
