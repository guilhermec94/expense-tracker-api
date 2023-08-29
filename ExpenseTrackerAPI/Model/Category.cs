using AutoMapper;
using ExpenseTrackerAPI.CodeGen.Models;

namespace ExpenseTrackerAPI.Model
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
    }

    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<CategoryDTO, Category>();
            CreateMap<Category, CategoryDTO>();
        }
    }
}
