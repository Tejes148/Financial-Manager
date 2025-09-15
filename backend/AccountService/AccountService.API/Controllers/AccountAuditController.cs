using AccountService.Core.AccountAuditCore.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AccountService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountAuditController : ControllerBase
    {
        public readonly IMediator _mediatR;
        public AccountAuditController(IMediator mediator)
        {
            _mediatR = mediator;
        }

        [HttpGet("/userid={UserId}")]
        public async Task<IActionResult> GetAuditLogByUserIdQuery(Guid userID)
        {
            var query = new GetAuditLogsByUserIdQuery(userID);
            var result = _mediatR.Send(query);
            return Ok(result);
        }

        [HttpGet("/accountId={AccountId}")]
        public async Task<IActionResult>  GetAuditLogsByAccountIdQuery(Guid AccountId) 
        {
            var query = new GetAuditLogsByAccountIdQuery(AccountId);
            var result = _mediatR.Send(query);
            return Ok(result);
        }
    }
}
