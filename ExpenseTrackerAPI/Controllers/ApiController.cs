
using ExpenseTrackerAPI.CodeGen.Controllers;
using ExpenseTrackerAPI.CodeGen.Models;
using ExpenseTrackerAPI.Handlers;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ExpenseTrackerAPI.Controllers
{
    public class ApiController : DefaultApiController
    {
        private readonly IExpenseHandler _expenseHandler;
        private readonly ICategoryHandler _categoryHandler;
        public ApiController(IExpenseHandler expenseHandler, ICategoryHandler categoryHandler)
        {
            _expenseHandler = expenseHandler;
            _categoryHandler = categoryHandler;
        }

        public override Task<IActionResult> GetAllCategories([FromQuery(Name = "offset")] int? offset, [FromQuery(Name = "limit")] int? limit) => _categoryHandler.GetAll(offset, limit);

        public override Task<IActionResult> GetCategory([FromRoute(Name = "id"), Required] Guid id) => _categoryHandler.Get(id);

        public override Task<IActionResult> AddCategory([FromBody] CreateCategoryDTO createCategoryDTO) => _categoryHandler.Add(createCategoryDTO);

        public override Task<IActionResult> UpdateCategory([FromRoute(Name = "id"), Required] Guid id, [FromBody] UpdateCategoryDTO updateCategoryDTO) => _categoryHandler.Update(id, updateCategoryDTO);

        public override Task<IActionResult> DeleteCategory([FromRoute(Name = "id"), Required] Guid id) => _categoryHandler.Delete(id);

        public override Task<IActionResult> GetAllExpenses([FromQuery(Name = "offset")] int? offset, [FromQuery(Name = "limit")] int? limit) => _expenseHandler.GetAll(offset, limit);

        public override Task<IActionResult> GetExpense([FromRoute(Name = "id"), Required] Guid id) => _expenseHandler.Get(id);

        public override Task<IActionResult> AddExpense([FromBody] CreateExpenseDTO createExpenseDTO) => _expenseHandler.Add(createExpenseDTO);

        public override Task<IActionResult> UpdateExpense([FromRoute(Name = "id"), Required] Guid id, [FromBody] UpdateExpenseDTO updateExpenseDTO) => _expenseHandler.Update(id, updateExpenseDTO);

        public override Task<IActionResult> DeleteExpense([FromRoute(Name = "id"), Required] Guid id) => _expenseHandler.Delete(id);
    }
}
