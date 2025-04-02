using MediatR;
using TodoApp.Core.Interface;


namespace TodoApp.Application.Todos.Command
{
    public record AddTodoCommand(string Title, string Description) : IRequest<AddTodoResult>;
    public record AddTodoResult(Guid id);

    public class AddTodoCommandHandler : IRequestHandler<AddTodoCommand, AddTodoResult>
    {
        private readonly ITodoRepository _repository;

        public AddTodoCommandHandler(ITodoRepository repository)
        {
            _repository = repository;
        }

        public async Task<AddTodoResult> Handle(AddTodoCommand request, CancellationToken cancellationToken)
        {
            var todo = new TodoApp.Core.Domain.Todo // Fully qualify the Todo type to avoid namespace conflict
            {
                Id = Guid.NewGuid(),
                Title = request.Title,
                Description = request.Description,
                IsCompleted = false
            };

            await _repository.AddAsync(todo);
            return new AddTodoResult(todo.Id);
        }
    }
}
