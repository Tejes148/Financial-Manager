using AccountService.Core.AccountAuditCore.Command;
using AccountService.Core.AccountCore.Commands;
using AccountService.Core.Interfaces;
using MediatR;

namespace AccountService.Core.AccountCore.CommandHandlers
{
    public class UpdateAccountCommandHandler : IRequestHandler<UpdateAccountCommand, bool>
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IMediator _mediator;

        public UpdateAccountCommandHandler(IAccountRepository accountRepository, IMediator mediator)
        {
            _accountRepository = accountRepository ?? throw new ArgumentNullException(nameof(accountRepository));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(_mediator));
        }

        public async Task<bool> Handle(UpdateAccountCommand request, CancellationToken cancellationToken)
        {
            var account = await _accountRepository.GetAccountByAccountNumberAsync(request.Name, cancellationToken);
            if (account == null)
            {
                return false;
            }

            account.AccountType = request.AccountType;
            account.CurrentBalance = request.CurrentBalance;
            account.Provider = request.Provider;    
            account.AvailableBalance = request.AvailableBalance;
            account.Provider= request.Provider;

            await _accountRepository.UpdateAccountAsync(account, cancellationToken);

            // Log audit after update
            await _mediator.Send(new LogAccountAuditCommand(
                account.AccountId,
                account.UserId,
                "AccountUpdated",
                $"Balance updated to {account.CurrentBalance}, Type = {account.AccountType}"
            ), cancellationToken);

            return true;
        }
    }
}
