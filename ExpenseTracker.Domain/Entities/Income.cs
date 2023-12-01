using AutoMapper;
using ExpenseTracker.CodeGen.Models;
using ExpenseTracker.Domain.Common;

namespace ExpenseTracker.Domain.Entities
{
    public class Income : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public Guid CategoryID { get; set; }
        public Category Category { get; set; }
    }

    public class IncomeProfile : Profile
    {
        public IncomeProfile()
        {
            CreateMap<IncomeDTO, Income>().
                ForPath(dest => dest.CategoryID, opt => opt.MapFrom(x => x.Category.Id)).
                ForPath(dest => dest.Category, opt => opt.Ignore());
            CreateMap<Income, IncomeDTO>().
                ForPath(dest => dest.Category.Id, opt => opt.MapFrom(x => x.CategoryID)).
                ForPath(dest => dest.Date, opt => opt.MapFrom(x => x.Date.Date.ToString("yyyy-MM-dd")));
            CreateMap<CreateIncomeDTO, IncomeDTO>().
                ForPath(dest => dest.Category.Id, opt => opt.MapFrom(x => x.CategoryId));
            CreateMap<UpdateIncomeDTO, IncomeDTO>().
                ForPath(dest => dest.Category.Id, opt => opt.MapFrom(x => x.CategoryId));
        }
    }
}
