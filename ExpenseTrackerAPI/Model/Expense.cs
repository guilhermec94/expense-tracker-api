using AutoMapper;
using ExpenseTrackerAPI.CodeGen.Models;

namespace ExpenseTrackerAPI.Model
{
    public class Expense : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Category Category { get; set; }
    }

    public class ExpenseProfile : Profile
    {
        public ExpenseProfile()
        {
            CreateMap<ExpenseDTO, Expense>();
            CreateMap<Expense, ExpenseDTO>();
            CreateMap<CreateExpenseDTO, ExpenseDTO>().ForPath(dest => dest.Category.Id, opt => opt.MapFrom(x => x.CategoryId));
            CreateMap<UpdateExpenseDTO, ExpenseDTO>().ForPath(dest => dest.Category.Id, opt => opt.MapFrom(x => x.CategoryId));
        }
    }
}
