using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoApp.Application.Users.Command;

namespace TodoApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }
        /// <summary>
        /// Register a new user
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterUserCommand command)
        {
            var result = await _mediator.Send(command);
            if (result.HasErrors)
            {
                return BadRequest(new
                {
                    Success = false,
                    Errors = result.Errors
                });
            }

            return Ok(new
            {
                Success = true,
                Message = "User registered successfully"
            });
        }
        /// <summary>
        /// Login user
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginUserCommand command)
        {
            var token = await _mediator.Send(command);
            return Ok(token);
        }

        /// <summary>
        /// Reset password
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordCommand command)
        {
            var token = await _mediator.Send(command);
            return Ok(new { Token = token });
        }

        /// <summary>
        /// Reset password
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword(ResetPasswordCommand command)
        {
            var result = await _mediator.Send(command);
            return result ? Ok() : BadRequest("Password reset failed");
        }
    }
}
