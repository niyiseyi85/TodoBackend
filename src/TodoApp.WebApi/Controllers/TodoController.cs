using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using TodoApp.Application.Todos.Command;
using TodoApp.Application.Todos.Queries;
using TodoApp.Application.Users.Command;
using TodoApp.Core.Common.Pagination;

namespace TodoApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodosController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TodosController(IMediator mediator)
        {
            _mediator = mediator;
        }
        /// <summary>
        /// Add a new todo
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddTodo(AddTodoCommand command)
        {
            var todoId = await _mediator.Send(command);
            return Ok(todoId);
        }

        /// <summary>
        /// Get a todo by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTodo(Guid id)
        {
            var query = new GetTodoByIdQuery(id);
            var todo = await _mediator.Send(query);
            return Ok(todo);
        }
        /// <summary>
        /// Get all todos
        /// </summary>
        /// <returns></returns>

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAllTodos([FromQuery]PaginationRequest request)
        {
            var query = new GetAllTodosQuery(request);
            var todos = await _mediator.Send(query);
            return Ok(todos);
        }
        /// <summary>
        /// update a todo
        /// </summary>
        /// <param name="id"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTodo(UpdateTodoCommand command)
        {           
            await _mediator.Send(command);
            return NoContent();
        }
        /// <summary>
        /// Delete a todo
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize]  
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodo(Guid id)
        {
            var command = new DeleteTodoCommand(id);
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
