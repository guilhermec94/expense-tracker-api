using ExpenseTracker.Application.Abstractions;
using ExpenseTracker.SharedKernel.Utils;
using Microsoft.AspNetCore.Mvc;
using AppDomain = ExpenseTracker.Domain.Abstractions;

namespace ExpenseTracker.Application.Services
{
    public abstract class BaseService<D> : IBaseService<D> where D : class
    {
        protected readonly AppDomain.IBaseService<D> service;

        public BaseService(AppDomain.IBaseService<D> service)
        {
            this.service = service;
        }

        public async Task<IActionResult> GetAll(int? offset, int? limit)
        {
            var (data, pag) = await service.GetAll(offset, limit);
            return new OkObjectResult(new { data, pagination = pag });
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
