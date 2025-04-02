using Microsoft.EntityFrameworkCore;
using TodoApp.Core.Common.Pagination;
using TodoApp.Core.Domain;
using TodoApp.Core.Interface;
using TodoApp.Infrastructure.Data;

namespace TodoApp.Infrastructure.Repository
{
    public class TodoRepository : ITodoRepository
    {
        private readonly TodoDbContext _context;

        public TodoRepository(TodoDbContext context)
        {
            _context = context;
        }

        public async Task<Todo> GetByIdAsync(Guid id)
        {
            return await _context.Todos.FindAsync(id);
        }

        public async Task<PagedResult<Todo>> GetAllAsync(PaginationRequest request)
        {
            var query = _context.Todos.AsQueryable();

            var pageNumber = request.PageIndex;
            var pageSize = request.PageSize;
            var totalCount = await _context.Todos.CountAsync();
            var items = await query
                .OrderBy(t => t.Title)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PagedResult<Todo>(items, totalCount, pageNumber, pageSize);
        }

        public async Task AddAsync(Todo todo)
        {
            await _context.Todos.AddAsync(todo);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Todo todo)
        {
            _context.Todos.Update(todo);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var todo = await _context.Todos.FindAsync(id);
            if (todo != null)
            {
                _context.Todos.Remove(todo);
                await _context.SaveChangesAsync();
            }
        }
    }
}
