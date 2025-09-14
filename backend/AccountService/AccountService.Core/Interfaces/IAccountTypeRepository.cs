using AccountService.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountService.Core.Interfaces
{
    public interface IAccountTypeRepository
    {
        // Define repository methods here
        // Create
        Task<AccountType> AddAccountTypeAsync(AccountType accountType, CancellationToken cancellationToken);

        // Update
        Task<AccountType> UpdateAccountTypeAsync(AccountType accountType, CancellationToken cancellationToken);

        // Delete
        Task<bool> DeleteAccountTypeAsync(string typeCode, CancellationToken cancellationToken = default);

        // Queries
        Task<AccountType?> GetAccountTypeByCodeAsync(string typeCode, CancellationToken cancellationToken = default);
        Task<IEnumerable<AccountType>> GetAllAccountTypesAsync(CancellationToken cancellationToken = default);
    }
}
