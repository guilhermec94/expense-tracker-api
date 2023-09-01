using ExpenseTrackerAPI.CodeGen.Models;
using ExpenseTrackerAPI.Services;
using ExpenseTrackerAPI.Utils;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTrackerAPI.Handlers
{
    public interface ICategoryHandler : IBaseHandler<CategoryDTO>
    {
        Task<IActionResult> Add(CreateCategoryDTO dto);
        Task<IActionResult> Update(Guid id, UpdateCategoryDTO dto);
    }
    public class CategoryHandler : BaseHandler<CategoryDTO>, ICategoryHandler
    {
        private readonly ICategoryService _service;
        public CategoryHandler(ICategoryService service) : base(service)
        {
            _service = service;
        }

        public async Task<IActionResult> Add(CreateCategoryDTO dto)
        {
            var (res, status) = await _service.Create(dto);
            return status.GetActionResult(res);
        }

        public async Task<IActionResult> Update(Guid id, UpdateCategoryDTO dto)
        {
            var status = await _service.Update(id, dto);
            return status.GetActionResult();
        }
    }
}
