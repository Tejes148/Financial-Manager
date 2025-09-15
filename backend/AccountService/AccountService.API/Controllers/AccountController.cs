using AccountService.Core.AccountCore.Commands;
using AccountService.Core.AccountCore.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

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

        // Create A/C
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

        [HttpGet]
        public async Task<IActionResult> GetAccountByAccountNumber(string accountNumber)
        {
            if (string.IsNullOrEmpty(accountNumber))
            {
                return BadRequest("AccountId cannot be empty.");
            }
            try
            {
                var query = new GetAccountsByAccountNumberQuery(accountNumber);
                var account = await _mediator.Send(query);
                if (account == null)
                {
                    return NotFound($"Account with ID {accountNumber} not found.");
                }
                return Ok(account);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while processing your request. " + ex.Message);
            }
        }

        // Update A/C
        [HttpPut]
        public async Task<IActionResult> UpdateAccount([FromBody] UpdateAccountCommand command)
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

        [HttpDelete("/{AccountNumber}")]
        public async Task<IActionResult> DeleteAccount(string AccountNumber)
        {
            if (string.IsNullOrEmpty(AccountNumber))
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
                var command = new CloseAccountCommand(AccountNumber);
                var accountId = await _mediator.Send(command);
                return Ok(accountId);

            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while processing your request. " + ex.Message);
            }
        }

        [HttpGet("/{userId}")]
        public async Task<IActionResult> GetAllAccountByUserId(Guid userId) 
        {

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
                var query = new GetAllAccountsQuery(userId);
                var accountId = await _mediator.Send(query);
                return Ok(accountId);

            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while processing your request. " + ex.Message);
            }
        }
    }
}
