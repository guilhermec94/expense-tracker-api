using ExpenseTrackerAPI.CodeGen.Models;
using ExpenseTrackerAPI.Services;

namespace ExpenseTrackerAPI.Handlers
{
    public interface ICategoryHandler : IBaseHandler<CategoryDTO>
    {

    }
    public class CategoryHandler : BaseHandler<CategoryDTO>, ICategoryHandler
    {
        public CategoryHandler(IBaseService<CategoryDTO> service) : base(service)
        {
        }
    }
}
