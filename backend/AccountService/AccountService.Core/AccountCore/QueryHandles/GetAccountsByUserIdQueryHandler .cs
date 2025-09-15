using AccountService.Core.AccountCore.Queries;
using AccountService.Core.Entities;
using AccountService.Core.Interfaces;
using MediatR;

namespace AccountService.Core.AccountCore.QueryHandles
{
    public  class GetAccountsByAccountNumberQueryHandler : IRequestHandler<GetAccountsByAccountNumberQuery,Account>
    {
        private readonly IAccountRepository _accountRepository;

        public GetAccountsByAccountNumberQueryHandler(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository ?? throw new ArgumentNullException(nameof(accountRepository));
        }

        public async Task<Account> Handle(GetAccountsByAccountNumberQuery request, CancellationToken cancellationToken)
        {
            return await _accountRepository.GetAccountByAccountNumberAsync(request.AccountNumber,cancellationToken);
        }

    }
}
