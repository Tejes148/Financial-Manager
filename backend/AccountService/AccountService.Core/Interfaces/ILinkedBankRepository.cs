using AccountService.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountService.Core.Interfaces
{
    public interface ILinkedBankRepository
    {
        Task<Guid> LinkedBankAccount(LinkedBankAccount linkedBankAccount, CancellationToken cancellationToken);
        Task<Guid> UnLinkedBankAccount(Guid linkedBankAccountID, CancellationToken cancellationToken);
        Task<LinkedBankAccount> GetLinkedBankByAccountId(Guid linkedBankAccountID, CancellationToken cancellationToken);
    }
}
