using MediatR;
using UserService.Core.DTOs;

namespace UserService.Core.Commands.LoginUser
{
    public record LoginUserCommand(string EmailId, string Password) : IRequest<LoginUserResultDTO>;
    
}
