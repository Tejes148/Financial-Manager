using Microsoft.AspNetCore.Mvc;
using MediatR;
using AccountService.Core.AccountCore.Commands;
using AccountService.Core.AccountCore.Queries;

namespace AccountService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IMediator _mediator;
        AccountController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        // Create A/c
        [HttpPost]
        public async Task<IActionResult> CreateAccount([FromBody] CreateAccountCommand command)
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
                var accountId = await _mediator.Send(command);
                return Ok(accountId);

            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while processing your request. " + ex.Message);
            }
        }

        public async Task<IActionResult> GetAccountById(Guid accountId)
        {
            if (accountId == Guid.Empty)
            {
                return BadRequest("AccountId cannot be empty.");
            }
            try
            {
                var query = new GetAccountByIdQuery(accountId);
                var account = await _mediator.Send(query);
                if (account == null)
                {
                    return NotFound($"Account with ID {accountId} not found.");
                }
                return Ok(account);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while processing your request. " + ex.Message);
            }
        }

    }
}
