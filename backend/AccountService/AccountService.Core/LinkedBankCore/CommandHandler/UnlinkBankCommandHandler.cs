using AccountService.Core.Interfaces;
using AccountService.Core.LinkedBankCore.Command;
using MediatR;


namespace AccountService.Core.LinkedBankCore.CommandHandler
{
    public class UnlinkBankCommandHandler : IRequestHandler<UnLinkBankAccountCommand, Guid>
    {
        private readonly ILinkedBankRepository _repository;
        public UnlinkBankCommandHandler(ILinkedBankRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(_repository));
        }

        public async Task<Guid> Handle(UnLinkBankAccountCommand request, CancellationToken cancellationToken)
        {
            var result = await _repository.UnLinkedBankAccount(request.AccountID, cancellationToken);
            return result;
        }
    }
}
