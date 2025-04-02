
using MediatR;
using TodoApp.Core.Interface;

namespace TodoApp.Application.Todos.Command
{
    public record DeleteTodoCommand(Guid Id) : IRequest<DeleteTodoResult>;
    public record DeleteTodoResult(bool success);
  
    public class DeleteTodoCommandHandler : IRequestHandler<DeleteTodoCommand, DeleteTodoResult>
    {
        private readonly ITodoRepository _repository;

        public DeleteTodoCommandHandler(ITodoRepository repository)
        {
            _repository = repository;
        }

        public async Task<DeleteTodoResult> Handle(DeleteTodoCommand request, CancellationToken cancellationToken)
        {
            await _repository.DeleteAsync(request.Id);
            return new DeleteTodoResult(true);
        }
    }
}
