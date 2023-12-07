using ExpenseTracker.Application.Abstractions;
using ExpenseTracker.CodeGen.Models;
using ExpenseTracker.SharedKernel.Utils;
using Microsoft.AspNetCore.Mvc;
using AppDomain = ExpenseTracker.Domain.Abstractions;

namespace ExpenseTracker.Application.Services
{
    public sealed class ExpenseService : BaseService<ExpenseDTO>, IExpenseService
    {
        private readonly AppDomain.IExpenseService _service;
        public ExpenseService(AppDomain.IExpenseService service) : base(service)
        {
            _service = service;
        }

        public async Task<IActionResult> Add(CreateExpenseDTO dto)
        {
            var (res, status) = await _service.Create(dto);
            return status.GetActionResult(res);
        }

        public async Task<IActionResult> Update(Guid id, UpdateExpenseDTO dto)
        {
            var status = await _service.Update(id, dto);
            return status.GetActionResult();
        }
    }
}
