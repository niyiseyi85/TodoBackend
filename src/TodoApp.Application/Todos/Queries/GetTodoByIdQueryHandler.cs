using MediatR;
using TodoApp.Core.Domain;
using TodoApp.Core.Interface;

namespace TodoApp.Application.Todos.Queries
{
    public record GetTodoByIdQuery(Guid Id) : IRequest<Todo>;
    public class GetTodoByIdQueryHandler : IRequestHandler<GetTodoByIdQuery, Todo>
    {
        

        private readonly ITodoRepository _repository;

        public GetTodoByIdQueryHandler(ITodoRepository repository)
        {
            _repository = repository;
        }

        public async Task<Todo> Handle(GetTodoByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetByIdAsync(request.Id);
        }
    }
}
