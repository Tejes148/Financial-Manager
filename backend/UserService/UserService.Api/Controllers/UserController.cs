using MediatR;
using Microsoft.AspNetCore.Mvc;
using UserService.Core.Commands.RegisterUser;
using UserService.Core.FluentValidation;

namespace UserService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        /// <summary>
        /// Registers a new user.
        /// </summary>
        /// <param name="command">The registration command.</param>
        /// <returns>The ID of the newly created user.</returns>
        [HttpPost("RegisterUser")]
        [ProducesResponseType(typeof(Guid), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterUserCommand command)
        {
            if (command == null)
            {
                return BadRequest("Request body cannot be null.");
            }

            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();

                return BadRequest(errors);

            }

            try
            {
                var validator = new RegisterUserCommandValidator();
                var result = validator.Validate(command);
                if (!result.IsValid)
                {
                    return BadRequest(result.Errors.Select(e => e.ErrorMessage));
                }

                var userId = await _mediator.Send(command);
                return Ok(userId);
            }
            catch (Exception ex)
            {
                // Log the exception (logging not shown here)
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
    }
}
