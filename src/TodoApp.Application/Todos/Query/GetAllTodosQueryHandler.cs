//using MediatR;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using TodoApp.Core.Domain;
//using TodoApp.Core.Interface;

//namespace TodoApp.Application.Todos.Query
//{
//    public record GetAllTodosQuery : IRequest<List<Todo>>;

   
//    public class GetAllTodosQueryHandler : IRequestHandler<GetAllTodosQuery, List<Todo>>
//    {
//        private readonly ITodoRepository _repository;

//        public GetAllTodosQueryHandler(ITodoRepository repository)
//        {
//            _repository = repository;
//        }

//        public async Task<List<Todo>> Handle(GetAllTodosQuery request, CancellationToken cancellationToken)
//        {
//            return await _repository.GetAllAsync(request.R);
//        }
//    }
//}
