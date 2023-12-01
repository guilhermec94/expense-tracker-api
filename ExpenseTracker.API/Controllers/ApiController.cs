using ExpenseTracker.Application.Abstractions;
using ExpenseTracker.CodeGen.Controllers;
using ExpenseTracker.CodeGen.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ExpenseTracker.API.Controllers
{
    public class ApiController : DefaultApiController
    {
        private readonly ICategoryService _categoryService;
        private readonly IExpenseService _expenseService;
        private readonly IIncomeService _incomeService;
        public ApiController(ICategoryService categoryService, IExpenseService expenseService, IIncomeService incomeService)
        {
            _categoryService = categoryService;
            _expenseService = expenseService;
            _incomeService = incomeService;
        }

        [Authorize("read:category")]
        public override Task<IActionResult> GetAllCategories([FromQuery(Name = "offset")] int? offset, [FromQuery(Name = "limit")] int? limit) => _categoryService.GetAll(offset, limit);

        [Authorize("read:category")]
        public override Task<IActionResult> GetCategory([FromRoute(Name = "id"), Required] Guid id) => _categoryService.Get(id);

        [Authorize("create:category")]
        public override Task<IActionResult> AddCategory([FromBody] CreateCategoryDTO createCategoryDTO) => _categoryService.Add(createCategoryDTO);

        [Authorize("update:category")]
        public override Task<IActionResult> UpdateCategory([FromRoute(Name = "id"), Required] Guid id, [FromBody] UpdateCategoryDTO updateCategoryDTO) => _categoryService.Update(id, updateCategoryDTO);

        [Authorize("delete:category")]
        public override Task<IActionResult> DeleteCategory([FromRoute(Name = "id"), Required] Guid id) => _categoryService.Delete(id);

        [Authorize("read:expense")]
        public override Task<IActionResult> GetAllExpenses([FromQuery(Name = "offset")] int? offset, [FromQuery(Name = "limit")] int? limit) => _expenseService.GetAll(offset, limit);

        [Authorize("read:expense")]
        public override Task<IActionResult> GetExpense([FromRoute(Name = "id"), Required] Guid id) => _expenseService.Get(id);

        [Authorize("create:expense")]
        public override Task<IActionResult> AddExpense([FromBody] CreateExpenseDTO createExpenseDTO) => _expenseService.Add(createExpenseDTO);

        [Authorize("update:expense")]
        public override Task<IActionResult> UpdateExpense([FromRoute(Name = "id"), Required] Guid id, [FromBody] UpdateExpenseDTO updateExpenseDTO) => _expenseService.Update(id, updateExpenseDTO);

        [Authorize("delete:expense")]
        public override Task<IActionResult> DeleteExpense([FromRoute(Name = "id"), Required] Guid id) => _expenseService.Delete(id);

        [Authorize("read:income")]
        public override Task<IActionResult> GetAllIncomes([FromQuery(Name = "offset")] int? offset, [FromQuery(Name = "limit")] int? limit) => _incomeService.GetAll(offset, limit);

        [Authorize("read:income")]
        public override Task<IActionResult> GetIncome([FromRoute(Name = "id"), Required] Guid id) => _incomeService.Get(id);

        [Authorize("create:income")]
        public override Task<IActionResult> AddIncome([FromBody] CreateIncomeDTO createIncomeDTO) => _incomeService.Add(createIncomeDTO);

        [Authorize("update:income")]
        public override Task<IActionResult> UpdateIncome([FromRoute(Name = "id"), Required] Guid id, [FromBody] UpdateIncomeDTO updateIncomeDTO) => _incomeService.Update(id, updateIncomeDTO);

        [Authorize("delete:income")]
        public override Task<IActionResult> DeleteIncome([FromRoute(Name = "id"), Required] Guid id) => _incomeService.Delete(id);

    }
}
