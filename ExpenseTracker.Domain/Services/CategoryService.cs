using AutoMapper;
using ExpenseTracker.CodeGen.Models;
using ExpenseTracker.Domain.Abstractions;
using ExpenseTracker.Domain.Entities;
using ExpenseTracker.SharedKernel.Utils;

namespace ExpenseTracker.Domain.Services
{
    public class CategoryService : BaseService<Category, CategoryDTO>, ICategoryService
    {
        public CategoryService(ICategoryRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }

        public async Task<(CategoryDTO dto, RequestResultStatus status)> Create(CreateCategoryDTO dto)
        {
            var entity = base._mapper.Map<CategoryDTO>(dto);
            return await base.Create(entity);
        }

        public async Task<RequestResultStatus> Update(Guid id, UpdateCategoryDTO dto)
        {
            var entity = base._mapper.Map<CategoryDTO>(dto);
            return await base.Update(id, entity);
        }
    }
}
