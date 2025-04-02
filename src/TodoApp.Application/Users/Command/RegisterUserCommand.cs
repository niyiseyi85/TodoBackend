using MediatR;
using Microsoft.AspNetCore.Identity;
using TodoApp.Core.Common.ResponseModel;
using TodoApp.Core.Domain;

namespace TodoApp.Application.Users.Command
{
    public record RegisterUserCommand(string Email, string Password, string FirstName, string LastName ) : IRequest<Response>;

    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, Response>
    {
        private readonly UserManager<User> _userManager;

        public RegisterUserCommandHandler(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<Response> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {            
            var user = new User { UserName = request.Email, Email = request.Email, FirstName = request.FirstName, LastName = request.LastName,  DateCreated = DateTime.UtcNow, ModifiedDate = DateTime.UtcNow, IsActive = true, IsDeleted = false};
            var result = await _userManager.CreateAsync(user, request.Password);

            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(x => new Error
                {
                    PropertyName = x.Code,
                    ErrorMessage = x.Description
                }).ToList();

                return Response.FromErrors(errors);
            }
            return Response.Success();

            //return response.AsResponse();
        }
    }
}
