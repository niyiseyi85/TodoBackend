using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Core.Common.Pagination;
using TodoApp.Core.Domain;

namespace TodoApp.Core.Interface
{
    /// <summary>
    /// Defines the contract for managing todo items in the database.
    /// </summary>
    public interface ITodoRepository
    {
        /// <summary>
         /// Retrieves a todo by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the todo.</param>
        /// <returns>The todo item if found; otherwise, null.</returns>
        Task<Todo> GetByIdAsync(Guid id);
        /// <summary>
        /// Get all the list of todos.
        /// </summary>
        /// <returns></returns>
        Task<PagedResult<Todo>> GetAllAsync(PaginationRequest request);
        /// <summary>
        /// Adds a new todo to the database.
        /// </summary>
        /// <param name="todo">The todo item to add.</param>
        Task AddAsync(Todo todo);
        /// <summary>
        /// Updates an existing todo in the database.
        /// </summary>
        /// <param name="todo">The todo item to update.</param>
        Task UpdateAsync(Todo todo);
        /// <summary>
        /// Deletes a todo from the database.
        /// </summary>
        /// <param name="id">The unique identifier of the todo to delete.</param>
        Task DeleteAsync(Guid id);        
    }
}
