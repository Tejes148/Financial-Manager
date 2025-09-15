using AccountService.Core.AccountCore.Queries;
using AccountService.Core.Entities;
using AccountService.Core.Interfaces;
using MediatR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountService.Core.AccountCore.QueryHandles
{
    public class GetAllAccountsQueryHandler : IRequestHandler<GetAllAccountsQuery, IEnumerable<Account>>
    {
        private readonly IAccountRepository _accountRepository;

        public GetAllAccountsQueryHandler(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository ?? throw new ArgumentNullException(nameof(accountRepository));
        }

        public async Task<IEnumerable<Account>> Handle(GetAllAccountsQuery request, CancellationToken cancellationToken)
        {
            return await _accountRepository.GetAllAccountsAsync(request.UserId, cancellationToken);
        }

    }
}
