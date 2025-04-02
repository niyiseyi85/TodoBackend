
using FluentValidation;
using TodoApp.Application.Todos.Command;

namespace TodoApp.Application.Todos.Validator
{
    public class AddTodoCommandValidator : AbstractValidator<AddTodoCommand>
    {
        public AddTodoCommandValidator()
        {
            RuleFor(x => x.Title).NotEmpty().MaximumLength(100);
            RuleFor(x => x.Description).MaximumLength(500);
        }
    }
}
