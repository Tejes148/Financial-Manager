using AccountService.Core.Entities;
using MediatR;

namespace AccountService.Core.AccountCore.Queries
{
    public class GetAccountsByAccountNumberQuery : IRequest<Account>
    {
        public string AccountNumber {  get; set; }
        public GetAccountsByAccountNumberQuery(string accountNumber)
        {
            AccountNumber = accountNumber;
        }
    }
}
