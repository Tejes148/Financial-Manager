using AccountService.Core.AccountCore.Commands;
using AccountService.Core.Interfaces;
using MediatR;
using AccountService.Core.Entities;

namespace AccountService.Core.AccountCore.CommandHandlers
{
    public class CreateAccountCommandHandler : IRequestHandler<CreateAccountCommand, Guid>
    {
        private readonly IAccountRepository _accountRepository;

        public CreateAccountCommandHandler(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository ?? throw new ArgumentNullException(nameof(accountRepository));
        }

        public async Task<Guid> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
        {
            var account = new Account
            {
                UserId = request.UserId,
                AccountType = request.AccountType,
                Name = request.Name,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            await _accountRepository.AddAccountAsync(account, cancellationToken); 

            return account.AccountId; 
        }
    }
}
