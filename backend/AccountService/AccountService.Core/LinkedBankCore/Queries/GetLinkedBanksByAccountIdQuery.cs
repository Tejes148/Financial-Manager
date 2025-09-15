using AccountService.Core.Entities;
using MediatR;

namespace AccountService.Core.LinkedBankCore.Queries
{
    public class GetLinkedBanksByAccountIdQuery : IRequest<LinkedBankAccount>
    {
        public Guid LinkedAccountId { get; set; }
    }
}
