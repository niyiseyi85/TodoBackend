using MediatR;
using TodoApp.Core.Common.Pagination;
using TodoApp.Core.Domain;
using TodoApp.Core.Interface;

namespace TodoApp.Application.Todos.Queries
{
    public record GetAllTodosQuery(PaginationRequest Request) : IRequest<PagedResult<Todo>>;


    public class GetAllTodosQueryHandler : IRequestHandler<GetAllTodosQuery, PagedResult<Todo>>
    {
        private readonly ITodoRepository _repository;

        public GetAllTodosQueryHandler(ITodoRepository repository)
        {
            _repository = repository;
        }

        public async Task<PagedResult<Todo>> Handle(GetAllTodosQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAllAsync(request.Request);
        }
    }
}
