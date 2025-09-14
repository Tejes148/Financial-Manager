using AccountService.Core.AccountTypeCore.Command;
using AccountService.Core.AccountTypeCore.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AccountService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountTypeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AccountTypeController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost]
        public async Task<IActionResult> CreateAccountType([FromBody] CreateAccountTypeCommand command)
        {
            if (command == null)
                return BadRequest("Invalid request");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("{typeCode}")]
        public async Task<IActionResult> UpdateAccountType(string typeCode, [FromBody] UpdateAccountTypeCommand command)
        {
            if (command == null)
                return BadRequest("Invalid request");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _mediator.Send(command);
            return Ok(result);
        }

      
        [HttpDelete("{typeCode}")]
        public async Task<IActionResult> DeleteAccountType(string typeCode)
        {
            if (typeCode == null)
                return BadRequest("Invalid request");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var command = new DeleteAccountTypeCommand(typeCode);
            await _mediator.Send(command);
            return NoContent();
        }
       
        [HttpGet]
        public async Task<IActionResult> GetAllAccountTypes()
        {
            var query = new GetAllAccountTypesQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{typeCode}")]
        public async Task<IActionResult> GetAccountTypeByCode(string typeCode)
        {
            var query = new GetAccountTypeByCodeQuery(typeCode);
            var result = await _mediator.Send(query);
            if (result == null)
                return NotFound();

            return Ok(result);
        }
    }
}
