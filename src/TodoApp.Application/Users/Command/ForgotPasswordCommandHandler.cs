using MediatR;
using Microsoft.AspNetCore.Identity;

using TodoApp.Core.Domain;

namespace TodoApp.Application.Users.Command
{
    public record ForgotPasswordCommand(string Email) : IRequest<string>;
   
    public class ForgotPasswordCommandHandler : IRequestHandler<ForgotPasswordCommand, string>
    {
        private readonly UserManager<User> _userManager;

        public ForgotPasswordCommandHandler(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<string> Handle(ForgotPasswordCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null)
            {
                throw new Exception("User not found");
            }

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            return token;
        }
    }
}
