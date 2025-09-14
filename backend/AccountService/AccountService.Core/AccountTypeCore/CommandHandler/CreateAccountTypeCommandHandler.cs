using AccountService.Core.AccountTypeCore.Command;
using AccountService.Core.Entities;
using AccountService.Core.Interfaces;
using MediatR;

namespace AccountService.Core.AccountTypeCore.CommandHandler
{
    internal class CreateAccountTypeCommandHandler : IRequestHandler<CreateAccountTypeCommand, AccountType>
    {
        private readonly IAccountTypeRepository _repository;

        public CreateAccountTypeCommandHandler(IAccountTypeRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<AccountType> Handle(CreateAccountTypeCommand request, CancellationToken cancellationToken)
        {
            var accountType = new AccountType
            {
                TypeCode = request.TypeCode,
                Description = request.Description,
            };

            var result = await _repository.AddAccountTypeAsync(accountType, cancellationToken);
            return result;
        }
    }
}
