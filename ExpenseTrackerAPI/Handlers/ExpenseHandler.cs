using ExpenseTrackerAPI.CodeGen.Models;
using ExpenseTrackerAPI.Services;
using ExpenseTrackerAPI.Utils;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTrackerAPI.Handlers
{
    public interface IExpenseHandler : IBaseHandler<ExpenseDTO>
    {
        Task<IActionResult> Add(CreateExpenseDTO dto);
        Task<IActionResult> Update(Guid id, UpdateExpenseDTO dto);
    }

    public class ExpenseHandler : BaseHandler<ExpenseDTO>, IExpenseHandler
    {
        private readonly IExpenseService _service;
        public ExpenseHandler(IExpenseService service) : base(service)
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
