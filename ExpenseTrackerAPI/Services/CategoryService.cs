﻿using AutoMapper;
using ExpenseTrackerAPI.CodeGen.Models;
using ExpenseTrackerAPI.Model;
using ExpenseTrackerAPI.Repositories;
using ExpenseTrackerAPI.Utils;

namespace ExpenseTrackerAPI.Services
{
    public interface ICategoryService : IBaseService<CategoryDTO>
    {
        Task<(CategoryDTO dto, RequestResultStatus status)> Create(CreateCategoryDTO dto);
        Task<RequestResultStatus> Update(Guid id, UpdateCategoryDTO dto);
    }
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
