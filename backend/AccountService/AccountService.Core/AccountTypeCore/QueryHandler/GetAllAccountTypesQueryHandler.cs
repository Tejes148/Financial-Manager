using AccountService.Core.AccountTypeCore.Queries;
using AccountService.Core.Entities;
using AccountService.Core.Interfaces;
using MediatR;

namespace AccountService.Core.AccountTypeCore.QueryHandler
{
    internal class GetAllAccountTypesQueryHandler : IRequestHandler<GetAllAccountTypesQuery, IEnumerable<AccountType>>
    {
        private readonly IAccountTypeRepository _repository;
        public GetAllAccountTypesQueryHandler(IAccountTypeRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public Task<IEnumerable<AccountType>> Handle(GetAllAccountTypesQuery request, CancellationToken cancellationToken) =>
           _repository.GetAllAccountTypesAsync(cancellationToken);

    }
}
