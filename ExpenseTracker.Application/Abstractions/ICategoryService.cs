using ExpenseTracker.CodeGen.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTracker.Application.Abstractions
{
    public interface ICategoryService : IBaseService<CategoryDTO>
    {
        Task<IActionResult> Add(CreateCategoryDTO dto);
        Task<IActionResult> Update(Guid id, UpdateCategoryDTO dto);
    }
}
