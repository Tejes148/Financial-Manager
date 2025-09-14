using AccountService.Core.AccountTypeCore.Command;
using AccountService.Core.Entities;
using AccountService.Core.Interfaces;
using MediatR;

namespace AccountService.Core.AccountTypeCore.CommandHandler
{
    internal class UpdateAccountTypeCommandHandler : IRequestHandler<UpdateAccountTypeCommand, AccountType>
    {
        private readonly IAccountTypeRepository _repository;
        public UpdateAccountTypeCommandHandler(IAccountTypeRepository accountTypeReposiotry)
        {
            _repository = accountTypeReposiotry ?? throw new ArgumentNullException(nameof(accountTypeReposiotry));
        }
        public async Task<AccountType> Handle(UpdateAccountTypeCommand request, CancellationToken cancellationToken)
        {
            var accountType = new AccountType
            {
                TypeCode = request.TypeCode,
                Description = request.Description,
            };

            var result = await _repository.UpdateAccountTypeAsync(accountType, cancellationToken);
            return result;
        }
    }
}
