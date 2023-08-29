using ExpenseTrackerAPI.Services;
using ExpenseTrackerAPI.Utils;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTrackerAPI.Handlers
{
    public interface IBaseHandler<D> where D : class
    {
        Task<IActionResult> Get(Guid id);
        Task<IActionResult> Add(D dto);
        Task<IActionResult> Update(Guid id, D dto);
        Task<IActionResult> Delete(Guid id);
    }
    public abstract class BaseHandler<D> : IBaseHandler<D> where D : class
    {
        protected readonly IBaseService<D> service;

        public BaseHandler(IBaseService<D> service)
        {
            this.service = service;
        }

        public async Task<IActionResult> Get(Guid id)
        {
            var (res, status) = await service.Get(id);
            return status.GetActionResult(res);
        }

        public async Task<IActionResult> Add(D dto)
        {
            var (res, status) = await service.Create(dto);
            return status.GetActionResult(res);
        }

        public async Task<IActionResult> Update(Guid id, D dto)
        {
            var status = await service.Update(id, dto);
            return status.GetActionResult();
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var status = await service.Delete(id);
            return status.GetActionResult();
        }
    }
}
