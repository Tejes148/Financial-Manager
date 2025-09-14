using AccountService.Core.AccountCore.Commands;
using AccountService.Core.Interfaces;
using MediatR;

namespace AccountService.Core.AccountCore.CommandHandlers
{
    public class UpdateAccountCommandHandler : IRequestHandler<UpdateAccountCommand, bool>
    {
        private readonly IAccountRepository _accountRepository;

        public UpdateAccountCommandHandler(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository ?? throw new ArgumentNullException(nameof(accountRepository));
        }

        public async Task<bool> Handle(UpdateAccountCommand request, CancellationToken cancellationToken)
        {
            var account = await _accountRepository.GetAccountByAccountIdAsync(request.AccountId, cancellationToken);
            if (account == null)
            {
                return false;
            }

            account.AccountType = request.AccountTypeCode;
            account.CurrentBalance = request.Balance;

            await _accountRepository.UpdateAccountAsync(account, cancellationToken);

            return true;
        }
    }
}
