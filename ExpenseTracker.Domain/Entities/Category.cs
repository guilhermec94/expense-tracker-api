using AutoMapper;
using ExpenseTracker.CodeGen.Models;
using ExpenseTracker.Domain.Common;

namespace ExpenseTracker.Domain.Entities
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
            CreateMap<CreateCategoryDTO, CategoryDTO>();
            CreateMap<UpdateCategoryDTO, CategoryDTO>();
        }
    }
}
