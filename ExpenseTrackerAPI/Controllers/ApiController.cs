using ExpenseTrackerAPI.CodeGen.Controllers;
using ExpenseTrackerAPI.CodeGen.Models;
using ExpenseTrackerAPI.Handlers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ExpenseTrackerAPI.Controllers
{
    public class ApiController : DefaultApiController
    {
        private readonly ICategoryHandler _categoryHandler;
        private readonly IExpenseHandler _expenseHandler;
        private readonly IIncomeHandler _incomeHandler;
        public ApiController(ICategoryHandler categoryHandler, IExpenseHandler expenseHandler, IIncomeHandler incomeHandler)
        {
            _categoryHandler = categoryHandler;
            _expenseHandler = expenseHandler;
            _incomeHandler = incomeHandler;
        }

        [Authorize("read:category")]
        public override Task<IActionResult> GetAllCategories([FromQuery(Name = "offset")] int? offset, [FromQuery(Name = "limit")] int? limit) => _categoryHandler.GetAll(offset, limit);

        [Authorize("read:category")]
        public override Task<IActionResult> GetCategory([FromRoute(Name = "id"), Required] Guid id) => _categoryHandler.Get(id);

        [Authorize("create:category")]
        public override Task<IActionResult> AddCategory([FromBody] CreateCategoryDTO createCategoryDTO) => _categoryHandler.Add(createCategoryDTO);

        [Authorize("update:category")]
        public override Task<IActionResult> UpdateCategory([FromRoute(Name = "id"), Required] Guid id, [FromBody] UpdateCategoryDTO updateCategoryDTO) => _categoryHandler.Update(id, updateCategoryDTO);

        [Authorize("delete:category")]
        public override Task<IActionResult> DeleteCategory([FromRoute(Name = "id"), Required] Guid id) => _categoryHandler.Delete(id);

        [Authorize("read:expense")]
        public override Task<IActionResult> GetAllExpenses([FromQuery(Name = "offset")] int? offset, [FromQuery(Name = "limit")] int? limit) => _expenseHandler.GetAll(offset, limit);

        [Authorize("read:expense")]
        public override Task<IActionResult> GetExpense([FromRoute(Name = "id"), Required] Guid id) => _expenseHandler.Get(id);

        [Authorize("create:expense")]
        public override Task<IActionResult> AddExpense([FromBody] CreateExpenseDTO createExpenseDTO) => _expenseHandler.Add(createExpenseDTO);

        [Authorize("update:expense")]
        public override Task<IActionResult> UpdateExpense([FromRoute(Name = "id"), Required] Guid id, [FromBody] UpdateExpenseDTO updateExpenseDTO) => _expenseHandler.Update(id, updateExpenseDTO);

        [Authorize("delete:expense")]
        public override Task<IActionResult> DeleteExpense([FromRoute(Name = "id"), Required] Guid id) => _expenseHandler.Delete(id);

        [Authorize("read:income")]
        public override Task<IActionResult> GetAllIncomes([FromQuery(Name = "offset")] int? offset, [FromQuery(Name = "limit")] int? limit) => _incomeHandler.GetAll(offset, limit);

        [Authorize("read:income")]
        public override Task<IActionResult> GetIncome([FromRoute(Name = "id"), Required] Guid id) => _incomeHandler.Get(id);

        [Authorize("create:income")]
        public override Task<IActionResult> AddIncome([FromBody] CreateIncomeDTO createIncomeDTO) => _incomeHandler.Add(createIncomeDTO);

        [Authorize("update:income")]
        public override Task<IActionResult> UpdateIncome([FromRoute(Name = "id"), Required] Guid id, [FromBody] UpdateIncomeDTO updateIncomeDTO) => _incomeHandler.Update(id, updateIncomeDTO);

        [Authorize("delete:income")]
        public override Task<IActionResult> DeleteIncome([FromRoute(Name = "id"), Required] Guid id) => _incomeHandler.Delete(id);

    }
}
