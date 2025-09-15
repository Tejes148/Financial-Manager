using AccountService.Core.LinkedBankCore.Command;
using AccountService.Core.LinkedBankCore.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AccountService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LinkedBanksController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LinkedBanksController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        /// Get linked account by Id
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetLinkedAccount(Guid id)
        {
            var query = new GetLinkedBanksByAccountIdQuery { LinkedAccountId = id };
            var result = await _mediator.Send(query);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// Create linked account
        [HttpPost]
        public async Task<IActionResult> CreateLinkedAccount([FromBody] LinkBankAccountCommand command)
        {
            var linkedAccountId = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetLinkedAccount), new { id = linkedAccountId }, linkedAccountId);
        }


        /// Delete linked account
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteLinkedAccount(Guid id)
        {
            var command = new UnLinkBankAccountCommand(id);
            var success = await _mediator.Send(command);

            if (string.IsNullOrEmpty(success.ToString()))
                return NotFound();

            return NoContent();
        }
    }
}
