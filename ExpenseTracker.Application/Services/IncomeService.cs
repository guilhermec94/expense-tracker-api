using ExpenseTracker.Application.Abstractions;
using ExpenseTracker.CodeGen.Models;
using ExpenseTracker.SharedKernel.Utils;
using Microsoft.AspNetCore.Mvc;
using AppDomain = ExpenseTracker.Domain.Abstractions;

namespace ExpenseTracker.Application.Services
{
    public sealed class IncomeService : BaseService<IncomeDTO>, IIncomeService
    {
        private readonly AppDomain.IIncomeService _service;
        public IncomeService(AppDomain.IIncomeService service) : base(service)
        {
            _service = service;
        }

        public async Task<IActionResult> Add(CreateIncomeDTO dto)
        {
            var (res, status) = await _service.Create(dto);
            return status.GetActionResult(res);
        }

        public async Task<IActionResult> Update(Guid id, UpdateIncomeDTO dto)
        {
            var status = await _service.Update(id, dto);
            return status.GetActionResult();
        }
    }
}
