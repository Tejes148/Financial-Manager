using AccountService.Core.Entities;
using AccountService.Core.Interfaces;
using AccountService.Core.LinkedBankCore.Queries;
using MediatR;

namespace AccountService.Core.LinkedBankCore.QueryHandler
{
    public class GetLinkedBanksByAccountIdQueryHandler : IRequestHandler<GetLinkedBanksByAccountIdQuery, LinkedBankAccount>
    {
        private readonly ILinkedBankRepository _repository;
        public GetLinkedBanksByAccountIdQueryHandler(ILinkedBankRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(_repository));
        }

        public async Task<LinkedBankAccount> Handle(GetLinkedBanksByAccountIdQuery request, CancellationToken cancellationToken)
        {
         
            var result= await _repository.GetLinkedBankByAccountId (request.LinkedAccountId, cancellationToken);
            return result;
        }
    }
}
