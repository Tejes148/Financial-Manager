using AccountService.Core.AccountTypeCore.Queries;
using AccountService.Core.Entities;
using AccountService.Core.Interfaces;
using MediatR;

namespace AccountService.Core.AccountTypeCore.QueryHandler
{
    internal class GetAccountTypeByCodeQueryHandler : IRequestHandler<GetAccountTypeByCodeQuery, AccountType>
    {
        private readonly IAccountTypeRepository _repository;
        public GetAccountTypeByCodeQueryHandler( IAccountTypeRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }
        public async Task<AccountType> Handle(GetAccountTypeByCodeQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetAccountTypeByCodeAsync(request.typeCode, cancellationToken);
            if (result is null)
                throw new InvalidOperationException($"AccountType with code '{request.typeCode}' not found.");
            return result;
        }
    }
}
