using AutoMapper;
using ExpenseTrackerAPI.CodeGen.Models;
using ExpenseTrackerAPI.Model;
using ExpenseTrackerAPI.Repositories;

namespace ExpenseTrackerAPI.Services
{
    public class CategoryService : BaseService<Category, CategoryDTO>
    {
        public CategoryService(IBaseRepository<Category> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
