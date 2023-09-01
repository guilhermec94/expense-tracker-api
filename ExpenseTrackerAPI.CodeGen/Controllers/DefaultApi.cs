/*
 * Expense Tracker API
 *
 * CRUD management of Expense Tracker
 *
 * The version of the OpenAPI document: 1.1.0
 * 
 * Generated by: https://openapi-generator.tech
 */

using ExpenseTrackerAPI.CodeGen.Attributes;
using ExpenseTrackerAPI.CodeGen.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace ExpenseTrackerAPI.CodeGen.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    public abstract class DefaultApiController : ControllerBase
    {
        /// <summary>
        /// Create a new category entry
        /// </summary>
        /// <param name="createCategoryDTO">Category payload</param>
        /// <response code="201">The newly created category</response>
        /// <response code="500">Unexpected error</response>
        [HttpPost]
        [Route("/api/v1/categories")]
        // [Authorize]
        [Consumes("application/json")]
        [ValidateModelState]
        [ProducesResponseType(statusCode: 201, type: typeof(CategoryDTO))]
        [ProducesResponseType(statusCode: 500, type: typeof(ErrorDTO))]
        public abstract Task<IActionResult> AddCategory([FromBody] CreateCategoryDTO createCategoryDTO);

        /// <summary>
        /// Create a new expense entry
        /// </summary>
        /// <param name="createExpenseDTO">Expense payload</param>
        /// <response code="201">The newly created expense</response>
        /// <response code="500">Unexpected error</response>
        [HttpPost]
        [Route("/api/v1/expenses")]
        // [Authorize]
        [Consumes("application/json")]
        [ValidateModelState]
        [ProducesResponseType(statusCode: 201, type: typeof(ExpenseDTO))]
        [ProducesResponseType(statusCode: 500, type: typeof(ErrorDTO))]
        public abstract Task<IActionResult> AddExpense([FromBody] CreateExpenseDTO createExpenseDTO);

        /// <summary>
        /// Delete an category
        /// </summary>
        /// <param name="id">The unique identifier</param>
        /// <response code="200">A category deleted</response>
        /// <response code="404">No category found for the provided &#x60;Id&#x60;</response>
        /// <response code="500">Unexpected error</response>
        [HttpDelete]
        [Route("/api/v1/categories/{id}")]
        // [Authorize]
        [ValidateModelState]
        [ProducesResponseType(statusCode: 404, type: typeof(ErrorDTO))]
        [ProducesResponseType(statusCode: 500, type: typeof(ErrorDTO))]
        public abstract Task<IActionResult> DeleteCategory([FromRoute(Name = "id")][Required] Guid id);

        /// <summary>
        /// Delete an expense
        /// </summary>
        /// <param name="id">The unique identifier</param>
        /// <response code="200">A expense deleted</response>
        /// <response code="404">No expense found for the provided &#x60;Id&#x60;</response>
        /// <response code="500">Unexpected error</response>
        [HttpDelete]
        [Route("/api/v1/expenses/{id}")]
        // [Authorize]
        [ValidateModelState]
        [ProducesResponseType(statusCode: 404, type: typeof(ErrorDTO))]
        [ProducesResponseType(statusCode: 500, type: typeof(ErrorDTO))]
        public abstract Task<IActionResult> DeleteExpense([FromRoute(Name = "id")][Required] Guid id);

        /// <summary>
        /// Fetch a list of expense
        /// </summary>
        /// <param name="offset">The number of items to skip before starting to collect the result set</param>
        /// <param name="limit">The numbers of items to return</param>
        /// <response code="200">A list of categories</response>
        /// <response code="500">Unexpected error</response>
        [HttpGet]
        [Route("/api/v1/categories")]
        // [Authorize]
        [ValidateModelState]
        [ProducesResponseType(statusCode: 200, type: typeof(List<CategoryDTO>))]
        [ProducesResponseType(statusCode: 500, type: typeof(ErrorDTO))]
        public abstract Task<IActionResult> GetAllCategories([FromQuery(Name = "offset")] int? offset, [FromQuery(Name = "limit")] int? limit);

        /// <summary>
        /// Fetch a list of expense
        /// </summary>
        /// <param name="offset">The number of items to skip before starting to collect the result set</param>
        /// <param name="limit">The numbers of items to return</param>
        /// <response code="200">A list of expenses</response>
        /// <response code="500">Unexpected error</response>
        [HttpGet]
        [Route("/api/v1/expenses")]
        // [Authorize]
        [ValidateModelState]
        [ProducesResponseType(statusCode: 200, type: typeof(List<ExpenseDTO>))]
        [ProducesResponseType(statusCode: 500, type: typeof(ErrorDTO))]
        public abstract Task<IActionResult> GetAllExpenses([FromQuery(Name = "offset")] int? offset, [FromQuery(Name = "limit")] int? limit);

        /// <summary>
        /// Fetch a category
        /// </summary>
        /// <param name="id">The unique identifier</param>
        /// <response code="200">A category</response>
        /// <response code="404">No category found for the provided &#x60;Id&#x60;</response>
        /// <response code="500">Unexpected error</response>
        [HttpGet]
        [Route("/api/v1/categories/{id}")]
        // [Authorize]
        [ValidateModelState]
        [ProducesResponseType(statusCode: 200, type: typeof(CategoryDTO))]
        [ProducesResponseType(statusCode: 404, type: typeof(ErrorDTO))]
        [ProducesResponseType(statusCode: 500, type: typeof(ErrorDTO))]
        public abstract Task<IActionResult> GetCategory([FromRoute(Name = "id")][Required] Guid id);

        /// <summary>
        /// Fetch a expense
        /// </summary>
        /// <param name="id">The unique identifier</param>
        /// <response code="200">A expense</response>
        /// <response code="404">No expense found for the provided &#x60;Id&#x60;</response>
        /// <response code="500">Unexpected error</response>
        [HttpGet]
        [Route("/api/v1/expenses/{id}")]
        // [Authorize]
        [ValidateModelState]
        [ProducesResponseType(statusCode: 200, type: typeof(ExpenseDTO))]
        [ProducesResponseType(statusCode: 404, type: typeof(ErrorDTO))]
        [ProducesResponseType(statusCode: 500, type: typeof(ErrorDTO))]
        public abstract Task<IActionResult> GetExpense([FromRoute(Name = "id")][Required] Guid id);

        /// <summary>
        /// Update an existing category entry
        /// </summary>
        /// <param name="id">The unique identifier</param>
        /// <param name="updateCategoryDTO">Category payload</param>
        /// <response code="204">The newly created category</response>
        /// <response code="500">Unexpected error</response>
        [HttpPut]
        [Route("/api/v1/categories/{id}")]
        // [Authorize]
        [Consumes("application/json")]
        [ValidateModelState]
        [ProducesResponseType(statusCode: 500, type: typeof(ErrorDTO))]
        public abstract Task<IActionResult> UpdateCategory([FromRoute(Name = "id")][Required] Guid id, [FromBody] UpdateCategoryDTO updateCategoryDTO);

        /// <summary>
        /// Update an existing expense entry
        /// </summary>
        /// <param name="id">The unique identifier</param>
        /// <param name="updateExpenseDTO">Expense payload</param>
        /// <response code="204">The newly created expense</response>
        /// <response code="500">Unexpected error</response>
        [HttpPut]
        [Route("/api/v1/expenses/{id}")]
        // [Authorize]
        [Consumes("application/json")]
        [ValidateModelState]
        [ProducesResponseType(statusCode: 500, type: typeof(ErrorDTO))]
        public abstract Task<IActionResult> UpdateExpense([FromRoute(Name = "id")][Required] Guid id, [FromBody] UpdateExpenseDTO updateExpenseDTO);
    }
}
