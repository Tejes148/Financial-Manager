using AccountService.Core.Entities;
using AccountService.Core.Interfaces;
using AccountService.Core.LinkedBankCore.Command;
using MediatR;

namespace AccountService.Core.LinkedBankCore.CommandHandler
{
    public class LinkBankCommandHandler : IRequestHandler<LinkBankAccountCommand, Guid>
    {
        private readonly ILinkedBankRepository _repository;
        public LinkBankCommandHandler(ILinkedBankRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(_repository));
        }

        public async Task<Guid> Handle(LinkBankAccountCommand request, CancellationToken cancellationToken)
        {

            var command = new LinkedBankAccount
            {
                AccountId = request.AccountId,
                Provider = request.Provider,
                ProviderAccountId = request.ProviderAccountId,
                RefreshToken = request.RefreshToken,
                Metadata = request.Metadata,
                CreatedAt = DateTime.UtcNow,
                LastSyncAt = DateTime.UtcNow,

            };

            var result = await _repository.LinkedBankAccount(command, cancellationToken);
            return result;
        }
    }
}

