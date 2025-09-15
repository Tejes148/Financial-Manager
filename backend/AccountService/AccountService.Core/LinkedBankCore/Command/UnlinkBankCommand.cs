using MediatR;

namespace AccountService.Core.LinkedBankCore.Command
{
    public record UnLinkBankAccountCommand(Guid AccountID) : IRequest<Guid>;

}
