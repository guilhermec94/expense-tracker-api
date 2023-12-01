using ExpenseTracker.Application.Abstractions;
using ExpenseTracker.CodeGen.Models;
using ExpenseTracker.SharedKernel.Utils;
using Microsoft.AspNetCore.Mvc;
using AppDomain = ExpenseTracker.Domain.Abstractions;

namespace ExpenseTracker.Application.Services
{
    public class CategoryService : BaseService<CategoryDTO>, ICategoryService
    {
        private readonly AppDomain.ICategoryService _service;
        public CategoryService(AppDomain.ICategoryService service) : base(service)
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
