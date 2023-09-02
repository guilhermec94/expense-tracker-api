using ExpenseTrackerAPI.CodeGen.Models;
using ExpenseTrackerAPI.Services;
using ExpenseTrackerAPI.Utils;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTrackerAPI.Handlers
{
    public interface IIncomeHandler : IBaseHandler<IncomeDTO>
    {
        Task<IActionResult> Add(CreateIncomeDTO dto);
        Task<IActionResult> Update(Guid id, UpdateIncomeDTO dto);
    }

    public class IncomeHandler : BaseHandler<IncomeDTO>, IIncomeHandler
    {
        private readonly IIncomeService _service;
        public IncomeHandler(IIncomeService service) : base(service)
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
