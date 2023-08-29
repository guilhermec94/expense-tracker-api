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
        public override Task<IActionResult> AddExpense([FromBody] ExpenseDTO expenseDTO) => _expenseHandler.Add(expenseDTO);

        public override Task<IActionResult> GetExpense([FromRoute(Name = "id"), Required] Guid id) => _expenseHandler.Get(id);
    }
}
