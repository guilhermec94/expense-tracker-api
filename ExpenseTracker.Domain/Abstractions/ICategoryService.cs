using ExpenseTracker.CodeGen.Models;
using ExpenseTracker.SharedKernel.Utils;

namespace ExpenseTracker.Domain.Abstractions
{
    public interface ICategoryService : IBaseService<CategoryDTO>
    {
        Task<(CategoryDTO dto, RequestResultStatus status)> Create(CreateCategoryDTO dto);
        Task<RequestResultStatus> Update(Guid id, UpdateCategoryDTO dto);
    }
}
