
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
        public ApiController(IExpenseHandler expenseHandler)
        {
            _expenseHandler = expenseHandler;
        }

        public override Task<IActionResult> GetAllCategories([FromQuery(Name = "offset")] int? offset, [FromQuery(Name = "limit")] int? limit)
        {
            throw new NotImplementedException();
        }

        public override Task<IActionResult> GetCategory([FromRoute(Name = "id"), Required] Guid id)
        {
            throw new NotImplementedException();
        }

        public override Task<IActionResult> AddCategory([FromBody] CreateCategoryDTO createCategoryDTO)
        {
            throw new NotImplementedException();
        }

        public override Task<IActionResult> UpdateCategory([FromRoute(Name = "id"), Required] Guid id, [FromBody] UpdateCategoryDTO updateCategoryDTO)
        {
            throw new NotImplementedException();
        }

        public override Task<IActionResult> DeleteCategory([FromRoute(Name = "id"), Required] Guid id)
        {
            throw new NotImplementedException();
        }

        public override Task<IActionResult> GetAllExpenses([FromQuery(Name = "offset")] int? offset, [FromQuery(Name = "limit")] int? limit)
        {
            throw new NotImplementedException();
        }

        public override Task<IActionResult> GetExpense([FromRoute(Name = "id"), Required] Guid id) => _expenseHandler.Get(id);

        public override Task<IActionResult> AddExpense([FromBody] CreateExpenseDTO createExpenseDTO) => _expenseHandler.Add(createExpenseDTO);

        public override Task<IActionResult> UpdateExpense([FromRoute(Name = "id"), Required] Guid id, [FromBody] UpdateExpenseDTO updateExpenseDTO)
        {
            throw new NotImplementedException();
        }

        public override Task<IActionResult> DeleteExpense([FromRoute(Name = "id"), Required] Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
