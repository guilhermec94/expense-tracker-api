using Microsoft.AspNetCore.Mvc;

namespace ExpenseTracker.Application.Abstractions
{
    public interface IBaseService<D> where D : class
    {
        Task<IActionResult> GetAll(int? offset, int? limit);
        Task<IActionResult> Get(Guid id);
        Task<IActionResult> Add(D dto);
        Task<IActionResult> Update(Guid id, D dto);
        Task<IActionResult> Delete(Guid id);
    }
}
