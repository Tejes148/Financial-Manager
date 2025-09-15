using AccountService.Core.AccountAuditCore.Command;
using AccountService.Core.AccountAuditCore.CommandHandler;
using AccountService.Core.AccountCore.Commands;
using AccountService.Core.Entities;
using AccountService.Core.Interfaces;
using MediatR;

namespace AccountService.Core.AccountCore.CommandHandlers
{
    public class CreateAccountCommandHandler : IRequestHandler<CreateAccountCommand, Guid>
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IMediator _mediator;

        public CreateAccountCommandHandler(IAccountRepository accountRepository, IMediator mediator)
        {
            _accountRepository = accountRepository ?? throw new ArgumentNullException(nameof(accountRepository));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(_mediator));
        }

        public async Task<Guid> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
        {
            var account = new Account
            {
                UserId = request.UserId,
                AccountType = request.AccountType,
                Name = request.Name,
                Provider = request.Provider,
                CurrentBalance = request.CurrentBalance,
                AvailableBalance = request.AvailableBalance,
                Currency = "INR",
                ExternalAccountId = "No",
                Status = 1,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            await _accountRepository.AddAccountAsync(account, cancellationToken);


            // Log audit after creation
            await _mediator.Send(new LogAccountAuditCommand(
                account.AccountId,
                request.UserId,
                "AccountCreated",
                $"Account {account.Name} created with type {account.AccountType}"
            ), cancellationToken);

            return account.AccountId; 
        }
    }
}
