using AccountService.Core.AccountCore.Commands;
using AccountService.Core.Entities;
using AccountService.Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountService.Core.AccountCore.CommandHandlers
{
    public class CloseAccountCommandHandler : IRequestHandler<CloseAccountCommand,bool>
    {
        private readonly IAccountRepository _accountRepository;

        public CloseAccountCommandHandler(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository ?? throw new ArgumentNullException(nameof(accountRepository));
        }

        public async Task<bool> Handle(CloseAccountCommand request, CancellationToken cancellationToken)
        {
           return await _accountRepository.DeleteAccountAsync(request.Name, cancellationToken);

        }
    }
}
