using AccountService.Core.AccountTypeCore.Command;
using AccountService.Core.Entities;
using AccountService.Core.Interfaces;
using MediatR;

namespace AccountService.Core.AccountTypeCore.CommandHandler
{
        internal class DeleteAccountTypeCommandHandler : IRequestHandler<DeleteAccountTypeCommand, bool>
        {
            private readonly IAccountTypeRepository _repository;
            public DeleteAccountTypeCommandHandler(IAccountTypeRepository accountTypeReposiotry)
            {
                _repository = accountTypeReposiotry ?? throw new ArgumentNullException(nameof(accountTypeReposiotry));
            }
            public async Task<bool> Handle(DeleteAccountTypeCommand request, CancellationToken cancellationToken)
            {
                string TypeCode = request.TypeCode;
               var result = await _repository.DeleteAccountTypeAsync(TypeCode, cancellationToken);
                return result;
            }
        }
}
