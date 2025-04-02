using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Core.Interface;

namespace TodoApp.Application.Todos.Command
{
    public record UpdateTodoCommand(Guid Id, string Title, string Description) : IRequest;

    public class UpdateTodoCommandHandler : IRequestHandler<UpdateTodoCommand>
    {
        private readonly ITodoRepository _repository;

        public UpdateTodoCommandHandler(ITodoRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateTodoCommand request, CancellationToken cancellationToken)
        {
            var todo = await _repository.GetByIdAsync(request.Id);
            if (todo == null)
            {
                throw new Exception("Todo not found");
            }

            todo.Title = request.Title;
            todo.Description = request.Description;
            //todo.IsCompleted = request.i

            await _repository.UpdateAsync(todo);
        }
    }
}
