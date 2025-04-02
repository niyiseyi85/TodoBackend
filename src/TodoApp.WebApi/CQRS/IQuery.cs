using MediatR;

namespace TodoApp.WebApi.CQRS;
public interface IQuery<out TResponse> : IRequest<TResponse>  
    where TResponse : notnull
{
}
